using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace DataScriptGenerator
{
    class GenerateScript
    {

     


        public bool CheckDBConnection(string strConnetion)
        {
            SqlConnection con = new SqlConnection(strConnetion);
            bool blResult = false;
            try
            {
                con.Open();
                blResult = true;
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            return blResult;
        }

        private DataTable GetData(string strConn,string strSql,SqlParameter sqlPa)
        {
            SqlConnection con = new SqlConnection(strConn);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand selCommand = new SqlCommand();
                selCommand.CommandType = CommandType.Text;
                selCommand.CommandText = strSql;
                if (sqlPa != null)
                {
                    selCommand.Parameters.Add(sqlPa);
                }
                selCommand.Connection = con;
                sda.SelectCommand = selCommand;

                sda.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }

        }
        public List<string> SearchTableName(string strName,string strConn)
        {
            SqlParameter pa = null;
            string strSql = " select name from sys.objects where type='U' AND name like @TableName order by name ";
            if (string.IsNullOrEmpty(strName) || strName.Trim() == string.Empty)
            {
                strSql = " select name from sys.objects where type='U'  order by name ";
            }
            else
            {
                pa = new SqlParameter();
                pa.ParameterName = "@TableName";
                pa.SqlDbType = SqlDbType.NVarChar;
                pa.Size = 100;
                pa.Value = "%" + strName + "%";
            }
            DataTable dt = GetData(strConn,strSql,pa);
            if (dt != null)
            {
                
                List<string> lst = new List<string>();
                string strTBName = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    strTBName = row["name"].ToString();
                    if (!lst.Contains(strTBName))
                    {
                        lst.Add(strTBName);
                    }
                }
                return lst;
            }

            return null;
        }

        //public void GenerateOneTableScriptFile(string strName)
        //{
        //    string strSql = string.Format(" select * from {0} ", strName);
        //    WriteSript(strSql, strName);
        //}

        public void GenerateScriptFile(string strConn,List<string> lstTableName,string strFilePath,string strQueryCondition,bool isOutputIdentity)
        {
            //List<string> lst = SearchTableName(strName);
            string strSql = string.Empty;
            for (int i = 0; i < lstTableName.Count; i++)
            {
                if (string.IsNullOrEmpty(strQueryCondition))
                {
                    strSql = string.Format(" select * from {0} ", lstTableName[i]);
                }
                else
                {
                    strSql = string.Format(" select * from {0} WHERE "+strQueryCondition, lstTableName[i]);
                }
                WriteSript(strConn, strSql, lstTableName[i], strFilePath, isOutputIdentity);
            }
        }


        private void WriteSript(string strConn, string strSql, string strTableName, string strFilePath, bool isOutputIdentity)
        {
            SqlParameter pa = new SqlParameter();
            pa.ParameterName = "@TableName";
            pa.SqlDbType = SqlDbType.NVarChar;
            pa.Value = strTableName;
            DataTable dt = GetData(strConn,strSql,pa);

            DataTable dtTableAttu = getTableColunms(strConn, strTableName);
            DataRow[] tableRows = dtTableAttu.Select("ISPkID='1' AND colstat='1' ");

            if (dt == null)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sb.Append("INSERT INTO  ");
            sb.Append(strTableName);
            sb.Append(" (");
            int i=0;
            foreach (DataColumn column in dt.Columns)
            {

                if (tableRows.Length > 0)
                {
                    if (!isOutputIdentity)
                    {
                        if (tableRows[0]["ColunmName"].ToString().Equals(column.ColumnName))
                        {
                            i++;
                            continue;
                        }
                    }
                        sb.Append(column.ColumnName);
                        sb.Append(",");
                        sbValue.Append("'{");
                        sbValue.Append(i.ToString());
                        sbValue.Append("}',");
                        i++;
                }
                else
                {
                    sb.Append(column.ColumnName);
                    sb.Append(",");
                    sbValue.Append("'{");
                    sbValue.Append(i.ToString());
                    sbValue.Append("}',");
                    i++;
                }
            }
            if (sb.ToString().EndsWith(","))
            {
                sb = sb.Remove(sb.Length-1,1);
            }
            if (sbValue.ToString().EndsWith(","))
            {
                sbValue = sbValue.Remove(sbValue.Length - 1, 1);
            }
            sb.Append(") VALUES (");
            sbValue.Append(")");
            string strScript = sb.ToString() + sbValue.ToString();
            string[] strData = new string[i];
            string strTemp = string.Empty;

            string strPath = strFilePath;
            if (!File.Exists(strPath))
            {
                using (FileStream fs = File.Create(strPath))
                {
                    fs.Close();
                }
            }
            using (StreamWriter sw = new StreamWriter(strPath, true))
            {
                sw.WriteLine("----" + strTableName+" "+DateTime.Now.ToShortTimeString());
                DataRow[] notNullableColumns = dtTableAttu.Select("isnullable='0'");
                List<string> notNullableColumnsName=new List<string>();
                if(notNullableColumns.Length>0)
                {
                    for(int k=0;k<notNullableColumns.Length;k++)
                    {
                        notNullableColumnsName.Add(notNullableColumns[k]["ColunmName"].ToString());
                    }
                }
                foreach (DataRow row in dt.Rows)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (notNullableColumnsName.Contains(dt.Columns[j].ColumnName))
                        {
                            if (string.IsNullOrEmpty(row[j].ToString()))
                            {
                                strData[j] = "[&quot&quot]";
                            }
                            else
                            {
                                strData[j] = row[j].ToString().Replace("'", "[&quot]");
                            }
                        }
                        else
                        {
                            strData[j] = row[j].ToString().Replace("'", "[&quot]");
                        }
                    }
                    strTemp = string.Format(strScript, strData);
                    strTemp = strTemp.Replace("''", "NULL");
                    strTemp = strTemp.Replace("[&quot]", "''");
                    strTemp = strTemp.Replace("'[&quot&quot]'", "''");
                    sw.WriteLine(strTemp);

                }
                sw.Close();
            }
        }

        public DataTable getTableColunms(string strConn,string tableName)
        {
            string strSQL = @"select  A.name as TableName,B.name as ColunmName,C.name TypeName,
                            case when D.COLUMN_NAME=B.name then '1' else '0' end as ISPkID,
                            E.colstat,E.isnullable
                            from sys.objects A
                            left join sys.columns B on A.object_id=B.object_id
                            left join sys.types C on B.system_type_id=C.user_type_id
                            left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE D on A.name=D.TABLE_NAME and D.constraint_name like 'PK%'
                            LEFT JOIN syscolumns E ON A.[object_id]=E.id AND B.[name]=E.[name]
                            where A.name=@TableName  ";

            SqlParameter pa = new SqlParameter();
            pa.ParameterName = "@TableName";
            pa.SqlDbType = SqlDbType.NVarChar;
            pa.Size = 100;
            pa.Value = tableName;

            return GetData(strConn, strSQL.ToString(), pa);
        }
    }
}

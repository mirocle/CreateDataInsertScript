using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace DataScriptGenerator
{
    public partial class Form1 : Form
    {
        private GenerateScript m_GenerateScript;
        public Form1()
        {
            InitializeComponent();
            m_GenerateScript = new GenerateScript();
            txtConn.Text = ConfigurationManager.AppSettings["DB"];
            txtFilePath.Text = ConfigurationManager.AppSettings["ScriptFilePath"];
        }

        

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (m_GenerateScript.CheckDBConnection(txtConn.Text))
            {
                MessageBox.Show("Test Connection DB Successful!");
            }
            else
            {
                MessageBox.Show("Test Connection DB Failed!");
            }
        }

        private void btnGetTable_Click(object sender, EventArgs e)
        {
            if (!m_GenerateScript.CheckDBConnection(txtConn.Text))
            {
                MessageBox.Show("DB Connection Failed!");
                return;
            }

            List<string> lst = m_GenerateScript.SearchTableName(txtTableName.Text, txtConn.Text);
            DataTable dt = CreateTable();
            for(int i=0;i<lst.Count;i++)
            {
                DataRow row = dt.NewRow();
                row["chk"] = "0";
                row["TableName"] = lst[i];
                dt.Rows.Add(row);
            }
            grdTable.DataSource = dt;


            datagridviewCheckboxHeaderCell ch = new datagridviewCheckboxHeaderCell();
            ch.OnCheckBoxClicked += new datagridviewcheckboxHeaderEventHander(ch_OnCheckBoxClicked);//关联单击事件


            
            DataGridViewCheckBoxColumn checkboxCol = grdTable.Columns["chk"] as DataGridViewCheckBoxColumn;
            checkboxCol.HeaderCell = ch;
            checkboxCol.HeaderCell.Value = string.Empty;//消除列头checkbox旁出现的文字 


            //chkTable.Items.Clear();
            //for (int i = 0; i < lst.Count; i++)
            //{
            //    chkTable.Items.Add(lst[i], false);    
            //}

        }
        private void ch_OnCheckBoxClicked(object sender, datagridviewCheckboxHeaderEventArgs e)
        {
            grdTable.CurrentRow.Selected = false;
            foreach (DataGridViewRow dgvRow in this.grdTable.Rows)
            {
                if (e.CheckedState)
                {
                    dgvRow.Cells["chk"].Value = "1";
                }
                else
                {
                    dgvRow.Cells["chk"].Value = "0";
                }
            }
        } 

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("chk", typeof(System.String));
            dt.Columns.Add("TableName", typeof(System.String));

            return dt;
        }
        

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (sfdFile.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = sfdFile.FileName;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Select Save File Path!");
                return;
            }
            if (!m_GenerateScript.CheckDBConnection(txtConn.Text))
            {
                MessageBox.Show("DB Connection Failed!");
                return;
            }

            //if (chkTable.CheckedItems.Count <= 0)
            //{
            //    MessageBox.Show("Please select Tables To Generate Script!");
            //    return;
            //}
            //Cursor.Current = Cursors.WaitCursor;
            //btnGenerate.Enabled = false;
            //btnGenerate.Text = "Generate Script Now...";
            //Application.DoEvents();
            List<string> lst = new List<string>();
            //for (int i = 0; i < chkTable.CheckedItems.Count; i++)
            //{
            //    if (!lst.Contains(chkTable.CheckedItems[i].ToString()))
            //    {
            //        lst.Add(chkTable.CheckedItems[i].ToString());
            //    }
            //}
            foreach (DataRow row in ((DataTable)grdTable.DataSource).Rows)
            {
                if (row["chk"].ToString() == "1")
                {
                    lst.Add(row["TableName"].ToString());
                }
            }
            m_GenerateScript.GenerateScriptFile(txtConn.Text, lst, txtFilePath.Text, txtQueryCondition.Text, chbIdentity.Checked);

            Cursor.Current = Cursors.Default;
            btnGenerate.Text = "Generate Script";
            btnGenerate.Enabled = true;
            MessageBox.Show("Generate Script Completely!");
        }




        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAll.Checked)
            //{
            //    for (int i = 0; i < chkTable.Items.Count; i++)
            //    {
            //        chkTable.SetItemChecked(i, true);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < chkTable.Items.Count; i++)
            //    {
            //        chkTable.SetItemChecked(i, false);
            //    }
            //}
        }

        private void grdTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = grdTable.CurrentRow.Index;
            if (grdTable.Columns[grdTable.CurrentCell.ColumnIndex].Name == "UP")
            {
                DataTable dt = (DataTable)grdTable.DataSource;
                DataTable dtNew = CreateTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == rowIndex - 1)
                    {
                        dtNew.ImportRow(dt.Rows[i + 1]);
                    }
                    else
                    {
                        if (i ==rowIndex && i!=0)
                        {
                            dtNew.ImportRow(dt.Rows[i - 1]);
                        }
                        else
                        {
                            dtNew.ImportRow(dt.Rows[i]);
                        }
                    }
                }
                grdTable.DataSource = dtNew;
                if (rowIndex != 0)
                {
                    grdTable.Rows[rowIndex - 1].Selected = true;
                    grdTable.FirstDisplayedScrollingRowIndex = rowIndex - 1;
                }
                else
                {
                    grdTable.Rows[rowIndex].Selected = true;
                    grdTable.FirstDisplayedScrollingRowIndex = rowIndex ;
                }
            }
            if (grdTable.Columns[grdTable.CurrentCell.ColumnIndex].Name == "DN")
            {
                DataTable dt = (DataTable)grdTable.DataSource;
                DataTable dtNew = CreateTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == rowIndex && i!=dt.Rows.Count-1)
                    {
                        dtNew.ImportRow(dt.Rows[i + 1]);
                    }
                    else
                    {
                        if (i == rowIndex+1)
                        {
                            dtNew.ImportRow(dt.Rows[i - 1]);
                        }
                        else
                        {
                            dtNew.ImportRow(dt.Rows[i]);
                        }
                    }
                }
                grdTable.DataSource = dtNew;
                if (rowIndex != dtNew.Rows.Count - 1)
                {
                    grdTable.Rows[rowIndex + 1].Selected = true;
                    grdTable.FirstDisplayedScrollingRowIndex = rowIndex + 1;
                }
                else
                {
                    grdTable.Rows[rowIndex].Selected = true;
                    grdTable.FirstDisplayedScrollingRowIndex = rowIndex;
                }
            }

            
        }



    }
}
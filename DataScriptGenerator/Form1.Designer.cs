namespace DataScriptGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.btnGetTable = new System.Windows.Forms.Button();
            this.sfdFile = new System.Windows.Forms.SaveFileDialog();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.txtQueryCondition = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grdTable = new System.Windows.Forms.DataGridView();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UP = new System.Windows.Forms.DataGridViewImageColumn();
            this.DN = new System.Windows.Forms.DataGridViewImageColumn();
            this.chbIdentity = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sql Server Connection String:";
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(19, 23);
            this.txtConn.Multiline = true;
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(331, 43);
            this.txtConn.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(231, 71);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(119, 21);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test Connection";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Table Name:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(94, 99);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(153, 21);
            this.txtTableName.TabIndex = 5;
            // 
            // btnGetTable
            // 
            this.btnGetTable.Location = new System.Drawing.Point(253, 98);
            this.btnGetTable.Name = "btnGetTable";
            this.btnGetTable.Size = new System.Drawing.Size(97, 21);
            this.btnGetTable.TabIndex = 6;
            this.btnGetTable.Text = "Get Table List";
            this.btnGetTable.UseVisualStyleBackColor = true;
            this.btnGetTable.Click += new System.EventHandler(this.btnGetTable_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(19, 377);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(285, 21);
            this.txtFilePath.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Save Script File Path:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(98, 405);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(149, 21);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate Script";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(310, 376);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(40, 21);
            this.btnSelectFile.TabIndex = 10;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(19, 340);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(84, 16);
            this.chkAll.TabIndex = 11;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtQueryCondition
            // 
            this.txtQueryCondition.Location = new System.Drawing.Point(19, 291);
            this.txtQueryCondition.Multiline = true;
            this.txtQueryCondition.Name = "txtQueryCondition";
            this.txtQueryCondition.Size = new System.Drawing.Size(331, 43);
            this.txtQueryCondition.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "Query Condition:";
            // 
            // grdTable
            // 
            this.grdTable.AllowDrop = true;
            this.grdTable.AllowUserToAddRows = false;
            this.grdTable.AllowUserToDeleteRows = false;
            this.grdTable.AllowUserToResizeColumns = false;
            this.grdTable.AllowUserToResizeRows = false;
            this.grdTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chk,
            this.TableName,
            this.UP,
            this.DN});
            this.grdTable.Location = new System.Drawing.Point(19, 132);
            this.grdTable.Name = "grdTable";
            this.grdTable.RowHeadersWidth = 20;
            this.grdTable.RowTemplate.Height = 23;
            this.grdTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdTable.Size = new System.Drawing.Size(331, 150);
            this.grdTable.TabIndex = 14;
            this.grdTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTable_CellClick);
            // 
            // chk
            // 
            this.chk.DataPropertyName = "chk";
            this.chk.FalseValue = "0";
            this.chk.HeaderText = "";
            this.chk.IndeterminateValue = "0";
            this.chk.Name = "chk";
            this.chk.TrueValue = "1";
            this.chk.Width = 20;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "表名称";
            this.TableName.Name = "TableName";
            this.TableName.Width = 230;
            // 
            // UP
            // 
            this.UP.HeaderText = "";
            this.UP.Image = ((System.Drawing.Image)(resources.GetObject("UP.Image")));
            this.UP.Name = "UP";
            this.UP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UP.Width = 20;
            // 
            // DN
            // 
            this.DN.HeaderText = "";
            this.DN.Image = ((System.Drawing.Image)(resources.GetObject("DN.Image")));
            this.DN.Name = "DN";
            this.DN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DN.Width = 20;
            // 
            // chbIdentity
            // 
            this.chbIdentity.AutoSize = true;
            this.chbIdentity.Location = new System.Drawing.Point(110, 339);
            this.chbIdentity.Name = "chbIdentity";
            this.chbIdentity.Size = new System.Drawing.Size(132, 16);
            this.chbIdentity.TabIndex = 15;
            this.chbIdentity.Text = "是否导出自增长字段";
            this.chbIdentity.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 446);
            this.Controls.Add(this.chbIdentity);
            this.Controls.Add(this.grdTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQueryCondition);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetTable);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.txtConn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grdTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConn;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btnGetTable;
        private System.Windows.Forms.SaveFileDialog sfdFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TextBox txtQueryCondition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewImageColumn UP;
        private System.Windows.Forms.DataGridViewImageColumn DN;
        private System.Windows.Forms.CheckBox chbIdentity;

    }
}


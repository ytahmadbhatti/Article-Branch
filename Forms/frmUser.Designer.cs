namespace POS.Forms
{
    partial class frmUser
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
            this.UserPanel = new System.Windows.Forms.Panel();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.cmbLoginType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCNICNo = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gdRights = new System.Windows.Forms.GroupBox();
            this.btnRights = new System.Windows.Forms.Button();
            this.chkSelecAll = new System.Windows.Forms.CheckBox();
            this.UserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // UserPanel
            // 
            this.UserPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.UserPanel.Controls.Add(this.chkSelecAll);
            this.UserPanel.Controls.Add(this.btnRights);
            this.UserPanel.Controls.Add(this.gdRights);
            this.UserPanel.Controls.Add(this.cbIsActive);
            this.UserPanel.Controls.Add(this.cmbLoginType);
            this.UserPanel.Controls.Add(this.label8);
            this.UserPanel.Controls.Add(this.txtUserPassword);
            this.UserPanel.Controls.Add(this.label7);
            this.UserPanel.Controls.Add(this.txtUserName);
            this.UserPanel.Controls.Add(this.label6);
            this.UserPanel.Controls.Add(this.txtPhoneNo);
            this.UserPanel.Controls.Add(this.label5);
            this.UserPanel.Controls.Add(this.txtSearch);
            this.UserPanel.Controls.Add(this.label4);
            this.UserPanel.Controls.Add(this.txtCNICNo);
            this.UserPanel.Controls.Add(this.btnDelete);
            this.UserPanel.Controls.Add(this.btnClear);
            this.UserPanel.Controls.Add(this.btnSearch);
            this.UserPanel.Controls.Add(this.btnAdd);
            this.UserPanel.Controls.Add(this.dgvUser);
            this.UserPanel.Controls.Add(this.label1);
            this.UserPanel.Controls.Add(this.txtName);
            this.UserPanel.Controls.Add(this.label2);
            this.UserPanel.Controls.Add(this.txtID);
            this.UserPanel.Controls.Add(this.label3);
            this.UserPanel.Location = new System.Drawing.Point(0, 1);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(1112, 577);
            this.UserPanel.TabIndex = 21;
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.cbIsActive.Location = new System.Drawing.Point(513, 214);
            this.cbIsActive.Margin = new System.Windows.Forms.Padding(2);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(91, 25);
            this.cbIsActive.TabIndex = 44;
            this.cbIsActive.Text = "IsActive";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // cmbLoginType
            // 
            this.cmbLoginType.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.cmbLoginType.FormattingEnabled = true;
            this.cmbLoginType.Items.AddRange(new object[] {
            "Manager",
            "Admin",
            "User"});
            this.cmbLoginType.Location = new System.Drawing.Point(151, 166);
            this.cmbLoginType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLoginType.Name = "cmbLoginType";
            this.cmbLoginType.Size = new System.Drawing.Size(247, 29);
            this.cmbLoginType.TabIndex = 43;
            this.cmbLoginType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cmbLoginType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbLoginType_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 21);
            this.label8.TabIndex = 42;
            this.label8.Text = "UserPassword";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtUserPassword.Location = new System.Drawing.Point(151, 216);
            this.txtUserPassword.MaxLength = 20;
            this.txtUserPassword.Multiline = true;
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(246, 24);
            this.txtUserPassword.TabIndex = 41;
            this.txtUserPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserPassword_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(411, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 21);
            this.label7.TabIndex = 40;
            this.label7.Text = "UserName";
            // 
            // txtUserName
            // 
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtUserName.Location = new System.Drawing.Point(506, 163);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(246, 24);
            this.txtUserName.TabIndex = 39;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 21);
            this.label6.TabIndex = 38;
            this.label6.Text = "Login Type";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNo.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPhoneNo.Location = new System.Drawing.Point(151, 123);
            this.txtPhoneNo.MaxLength = 50;
            this.txtPhoneNo.Multiline = true;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(246, 24);
            this.txtPhoneNo.TabIndex = 3;
            this.txtPhoneNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhoneNo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 21);
            this.label5.TabIndex = 36;
            this.label5.Text = "Phone No";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSearch.Location = new System.Drawing.Point(36, 347);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(505, 24);
            this.txtSearch.TabIndex = 35;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 21);
            this.label4.TabIndex = 34;
            this.label4.Text = "CNIC No";
            // 
            // txtCNICNo
            // 
            this.txtCNICNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCNICNo.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtCNICNo.Location = new System.Drawing.Point(506, 121);
            this.txtCNICNo.MaxLength = 20;
            this.txtCNICNo.Multiline = true;
            this.txtCNICNo.Name = "txtCNICNo";
            this.txtCNICNo.Size = new System.Drawing.Size(246, 24);
            this.txtCNICNo.TabIndex = 4;
            this.txtCNICNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCNICNo_KeyDown);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(526, 273);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 47);
            this.btnDelete.TabIndex = 32;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(413, 275);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 47);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(296, 273);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 47);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(183, 275);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 47);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Location = new System.Drawing.Point(34, 379);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersWidth = 62;
            this.dgvUser.Size = new System.Drawing.Size(972, 177);
            this.dgvUser.TabIndex = 28;
            this.dgvUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_CellClick);
            this.dgvUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUser_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 31);
            this.label1.TabIndex = 23;
            this.label1.Text = "User";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtName.Location = new System.Drawing.Point(506, 86);
            this.txtName.MaxLength = 50;
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 24);
            this.txtName.TabIndex = 2;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(411, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Name";
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtID.Location = new System.Drawing.Point(151, 84);
            this.txtID.MaxLength = 10;
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(246, 24);
            this.txtID.TabIndex = 1;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Id";
            // 
            // gdRights
            // 
            this.gdRights.BackColor = System.Drawing.SystemColors.MenuBar;
            this.gdRights.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdRights.Location = new System.Drawing.Point(776, 84);
            this.gdRights.Name = "gdRights";
            this.gdRights.Size = new System.Drawing.Size(134, 259);
            this.gdRights.TabIndex = 45;
            this.gdRights.TabStop = false;
            this.gdRights.Text = "User Rights";
            // 
            // btnRights
            // 
            this.btnRights.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRights.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnRights.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRights.Location = new System.Drawing.Point(641, 205);
            this.btnRights.Name = "btnRights";
            this.btnRights.Size = new System.Drawing.Size(104, 47);
            this.btnRights.TabIndex = 46;
            this.btnRights.Text = "Rights";
            this.btnRights.UseVisualStyleBackColor = false;
            this.btnRights.Click += new System.EventHandler(this.btnRights_Click);
            // 
            // chkSelecAll
            // 
            this.chkSelecAll.AutoSize = true;
            this.chkSelecAll.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.chkSelecAll.Location = new System.Drawing.Point(776, 54);
            this.chkSelecAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkSelecAll.Name = "chkSelecAll";
            this.chkSelecAll.Size = new System.Drawing.Size(73, 19);
            this.chkSelecAll.TabIndex = 47;
            this.chkSelecAll.Text = "Check All";
            this.chkSelecAll.UseVisualStyleBackColor = true;
            this.chkSelecAll.CheckedChanged += new System.EventHandler(this.chkSelecAll_CheckedChanged);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 574);
            this.Controls.Add(this.UserPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUser";
            this.UserPanel.ResumeLayout(false);
            this.UserPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCNICNo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cmbLoginType;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnRights;
        private System.Windows.Forms.GroupBox gdRights;
        private System.Windows.Forms.CheckBox chkSelecAll;
    }
}
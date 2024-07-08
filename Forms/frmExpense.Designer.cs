namespace POS.Forms
{
    partial class frmExpense
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
            this.pnlExpense = new System.Windows.Forms.Panel();
            this.cbPurpose = new System.Windows.Forms.ComboBox();
            this.dptDate = new System.Windows.Forms.DateTimePicker();
            this.txtDiscription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pnlExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlExpense
            // 
            this.pnlExpense.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlExpense.Controls.Add(this.cbPurpose);
            this.pnlExpense.Controls.Add(this.dptDate);
            this.pnlExpense.Controls.Add(this.txtDiscription);
            this.pnlExpense.Controls.Add(this.label9);
            this.pnlExpense.Controls.Add(this.label1);
            this.pnlExpense.Controls.Add(this.label4);
            this.pnlExpense.Controls.Add(this.txtSearch);
            this.pnlExpense.Controls.Add(this.dgvExpense);
            this.pnlExpense.Controls.Add(this.btnSearch);
            this.pnlExpense.Controls.Add(this.label5);
            this.pnlExpense.Controls.Add(this.btnAdd);
            this.pnlExpense.Controls.Add(this.btnDelete);
            this.pnlExpense.Controls.Add(this.btnClear);
            this.pnlExpense.Controls.Add(this.label2);
            this.pnlExpense.Controls.Add(this.txtID);
            this.pnlExpense.Location = new System.Drawing.Point(1, -1);
            this.pnlExpense.Name = "pnlExpense";
            this.pnlExpense.Size = new System.Drawing.Size(1089, 579);
            this.pnlExpense.TabIndex = 1;
            // 
            // cbPurpose
            // 
            this.cbPurpose.FormattingEnabled = true;
            this.cbPurpose.Location = new System.Drawing.Point(177, 312);
            this.cbPurpose.Name = "cbPurpose";
            this.cbPurpose.Size = new System.Drawing.Size(335, 21);
            this.cbPurpose.TabIndex = 31;
            this.cbPurpose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPurpose_KeyDown);
            // 
            // dptDate
            // 
            this.dptDate.Location = new System.Drawing.Point(177, 259);
            this.dptDate.Name = "dptDate";
            this.dptDate.Size = new System.Drawing.Size(335, 20);
            this.dptDate.TabIndex = 2;
            this.dptDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dptDate_KeyDown);
            // 
            // txtDiscription
            // 
            this.txtDiscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscription.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtDiscription.Location = new System.Drawing.Point(172, 365);
            this.txtDiscription.MaxLength = 1000;
            this.txtDiscription.Multiline = true;
            this.txtDiscription.Name = "txtDiscription";
            this.txtDiscription.Size = new System.Drawing.Size(335, 24);
            this.txtDiscription.TabIndex = 9;
            this.txtDiscription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscription_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(71, 366);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 21);
            this.label9.TabIndex = 30;
            this.label9.Text = "Discription ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expense";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(129, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSearch.Location = new System.Drawing.Point(566, 162);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(488, 24);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dgvExpense
            // 
            this.dgvExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpense.Location = new System.Drawing.Point(566, 207);
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.RowHeadersWidth = 62;
            this.dgvExpense.Size = new System.Drawing.Size(488, 199);
            this.dgvExpense.TabIndex = 10;
            this.dgvExpense.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellClick);
            this.dgvExpense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvExpense_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(228, 463);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 47);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(91, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Purpose ";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(115, 463);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 47);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(459, 463);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 47);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(344, 463);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 47);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtID.Location = new System.Drawing.Point(177, 207);
            this.txtID.MaxLength = 50;
            this.txtID.Multiline = true;
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(335, 24);
            this.txtID.TabIndex = 1;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // frmExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 578);
            this.Controls.Add(this.pnlExpense);
            this.MaximizeBox = false;
            this.Name = "frmExpense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense";
            this.pnlExpense.ResumeLayout(false);
            this.pnlExpense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlExpense;
        private System.Windows.Forms.DateTimePicker dptDate;
        private System.Windows.Forms.TextBox txtDiscription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cbPurpose;
    }
}
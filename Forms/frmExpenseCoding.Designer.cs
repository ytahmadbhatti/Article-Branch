namespace POS.Forms
{
    partial class frmExpenseCoding
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
            this.pnlExpenseCoding = new System.Windows.Forms.Panel();
            this.txtExpenseType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pnlExpenseCoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlExpenseCoding
            // 
            this.pnlExpenseCoding.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlExpenseCoding.Controls.Add(this.txtExpenseType);
            this.pnlExpenseCoding.Controls.Add(this.label1);
            this.pnlExpenseCoding.Controls.Add(this.txtSearch);
            this.pnlExpenseCoding.Controls.Add(this.dgvExpense);
            this.pnlExpenseCoding.Controls.Add(this.btnSearch);
            this.pnlExpenseCoding.Controls.Add(this.label5);
            this.pnlExpenseCoding.Controls.Add(this.btnAdd);
            this.pnlExpenseCoding.Controls.Add(this.btnDelete);
            this.pnlExpenseCoding.Controls.Add(this.btnClear);
            this.pnlExpenseCoding.Controls.Add(this.label2);
            this.pnlExpenseCoding.Controls.Add(this.txtID);
            this.pnlExpenseCoding.Location = new System.Drawing.Point(1, 0);
            this.pnlExpenseCoding.Name = "pnlExpenseCoding";
            this.pnlExpenseCoding.Size = new System.Drawing.Size(1089, 504);
            this.pnlExpenseCoding.TabIndex = 2;
            // 
            // txtExpenseType
            // 
            this.txtExpenseType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpenseType.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtExpenseType.Location = new System.Drawing.Point(177, 267);
            this.txtExpenseType.MaxLength = 1000;
            this.txtExpenseType.Multiline = true;
            this.txtExpenseType.Name = "txtExpenseType";
            this.txtExpenseType.Size = new System.Drawing.Size(335, 24);
            this.txtExpenseType.TabIndex = 2;
            this.txtExpenseType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExpenseType_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(171, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expense Coding";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSearch.Location = new System.Drawing.Point(566, 162);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(488, 24);
            this.txtSearch.TabIndex = 7;
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
            this.dgvExpense.Size = new System.Drawing.Size(488, 158);
            this.dgvExpense.TabIndex = 8;
            this.dgvExpense.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellClick);
            this.dgvExpense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvExpense_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(201, 402);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 47);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Expense Type ";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(88, 402);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 47);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(432, 402);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 47);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(317, 402);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 47);
            this.btnClear.TabIndex = 5;
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
            // frmExpenseCoding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 505);
            this.Controls.Add(this.pnlExpenseCoding);
            this.MaximizeBox = false;
            this.Name = "frmExpenseCoding";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExpenseCoding";
            this.Load += new System.EventHandler(this.frmExpenseCoding_Load);
            this.pnlExpenseCoding.ResumeLayout(false);
            this.pnlExpenseCoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlExpenseCoding;
        private System.Windows.Forms.TextBox txtExpenseType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
    }
}
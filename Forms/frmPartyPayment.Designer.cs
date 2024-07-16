namespace POS.Forms
{
    partial class frmPartyPayment
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
            this.pnlPartyPayment = new System.Windows.Forms.Panel();
            this.dptDate = new System.Windows.Forms.DateTimePicker();
            this.cbPartyName = new System.Windows.Forms.ComboBox();
            this.txtDiscription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAmountRemaining = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmountPending = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPartyID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVoucherID = new System.Windows.Forms.TextBox();
            this.pnlPartyPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPartyPayment
            // 
            this.pnlPartyPayment.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlPartyPayment.Controls.Add(this.dptDate);
            this.pnlPartyPayment.Controls.Add(this.cbPartyName);
            this.pnlPartyPayment.Controls.Add(this.txtDiscription);
            this.pnlPartyPayment.Controls.Add(this.label9);
            this.pnlPartyPayment.Controls.Add(this.txtAmountRemaining);
            this.pnlPartyPayment.Controls.Add(this.label8);
            this.pnlPartyPayment.Controls.Add(this.txtAmount);
            this.pnlPartyPayment.Controls.Add(this.label7);
            this.pnlPartyPayment.Controls.Add(this.txtAmountPending);
            this.pnlPartyPayment.Controls.Add(this.label6);
            this.pnlPartyPayment.Controls.Add(this.label3);
            this.pnlPartyPayment.Controls.Add(this.label1);
            this.pnlPartyPayment.Controls.Add(this.label4);
            this.pnlPartyPayment.Controls.Add(this.btnSearch);
            this.pnlPartyPayment.Controls.Add(this.txtPartyID);
            this.pnlPartyPayment.Controls.Add(this.label5);
            this.pnlPartyPayment.Controls.Add(this.btnAdd);
            this.pnlPartyPayment.Controls.Add(this.btnDelete);
            this.pnlPartyPayment.Controls.Add(this.btnClear);
            this.pnlPartyPayment.Controls.Add(this.label2);
            this.pnlPartyPayment.Controls.Add(this.txtVoucherID);
            this.pnlPartyPayment.Location = new System.Drawing.Point(1, -3);
            this.pnlPartyPayment.Name = "pnlPartyPayment";
            this.pnlPartyPayment.Size = new System.Drawing.Size(757, 662);
            this.pnlPartyPayment.TabIndex = 0;
            // 
            // dptDate
            // 
            this.dptDate.CustomFormat = "dd/MM/yyyy";
            this.dptDate.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptDate.Location = new System.Drawing.Point(235, 158);
            this.dptDate.Name = "dptDate";
            this.dptDate.Size = new System.Drawing.Size(333, 28);
            this.dptDate.TabIndex = 40;
            // 
            // cbPartyName
            // 
            this.cbPartyName.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.cbPartyName.FormattingEnabled = true;
            this.cbPartyName.Location = new System.Drawing.Point(235, 243);
            this.cbPartyName.Name = "cbPartyName";
            this.cbPartyName.Size = new System.Drawing.Size(335, 29);
            this.cbPartyName.TabIndex = 32;
            this.cbPartyName.TextChanged += new System.EventHandler(this.cbPartyName_TextChanged);
            // 
            // txtDiscription
            // 
            this.txtDiscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscription.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtDiscription.Location = new System.Drawing.Point(235, 424);
            this.txtDiscription.MaxLength = 1000;
            this.txtDiscription.Multiline = true;
            this.txtDiscription.Name = "txtDiscription";
            this.txtDiscription.Size = new System.Drawing.Size(335, 24);
            this.txtDiscription.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(134, 427);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 21);
            this.label9.TabIndex = 30;
            this.label9.Text = "Discription ";
            // 
            // txtAmountRemaining
            // 
            this.txtAmountRemaining.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountRemaining.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtAmountRemaining.Location = new System.Drawing.Point(235, 379);
            this.txtAmountRemaining.MaxLength = 1000;
            this.txtAmountRemaining.Multiline = true;
            this.txtAmountRemaining.Name = "txtAmountRemaining";
            this.txtAmountRemaining.Size = new System.Drawing.Size(335, 24);
            this.txtAmountRemaining.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(78, 380);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(153, 21);
            this.label8.TabIndex = 28;
            this.label8.Text = "Amount Remaining";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtAmount.Location = new System.Drawing.Point(235, 335);
            this.txtAmount.MaxLength = 1000;
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(335, 24);
            this.txtAmount.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(123, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "Amount Paid";
            // 
            // txtAmountPending
            // 
            this.txtAmountPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmountPending.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtAmountPending.Location = new System.Drawing.Point(235, 292);
            this.txtAmountPending.MaxLength = 1000;
            this.txtAmountPending.Multiline = true;
            this.txtAmountPending.Name = "txtAmountPending";
            this.txtAmountPending.Size = new System.Drawing.Size(335, 24);
            this.txtAmountPending.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(96, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 21);
            this.label6.TabIndex = 24;
            this.label6.Text = "Amount Pending";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 21);
            this.label3.TabIndex = 22;
            this.label3.Text = "Party Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Party Payment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(129, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Voucer Date";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(292, 477);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 47);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtPartyID
            // 
            this.txtPartyID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyID.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPartyID.Location = new System.Drawing.Point(235, 203);
            this.txtPartyID.MaxLength = 1000;
            this.txtPartyID.Multiline = true;
            this.txtPartyID.Name = "txtPartyID";
            this.txtPartyID.Size = new System.Drawing.Size(335, 24);
            this.txtPartyID.TabIndex = 3;
            this.txtPartyID.TextChanged += new System.EventHandler(this.txtPartyID_TextChanged);
            this.txtPartyID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyID_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(158, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Party ID";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(179, 477);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 47);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Save";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(523, 477);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 47);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(408, 477);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 47);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Voucher ID";
            // 
            // txtVoucherID
            // 
            this.txtVoucherID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVoucherID.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtVoucherID.Location = new System.Drawing.Point(240, 118);
            this.txtVoucherID.MaxLength = 50;
            this.txtVoucherID.Multiline = true;
            this.txtVoucherID.Name = "txtVoucherID";
            this.txtVoucherID.ReadOnly = true;
            this.txtVoucherID.Size = new System.Drawing.Size(335, 24);
            this.txtVoucherID.TabIndex = 1;
            // 
            // frmPartyPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 659);
            this.Controls.Add(this.pnlPartyPayment);
            this.MaximizeBox = false;
            this.Name = "frmPartyPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Party Payment";
            this.pnlPartyPayment.ResumeLayout(false);
            this.pnlPartyPayment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPartyPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPartyID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVoucherID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAmountRemaining;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAmountPending;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPartyName;
        private System.Windows.Forms.DateTimePicker dptDate;
    }
}
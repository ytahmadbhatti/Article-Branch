namespace POS.Report_Form
{
    partial class ReportForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ReportLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnShowReport);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ReportLabel);
            this.panel1.Location = new System.Drawing.Point(-1, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 317);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.Location = new System.Drawing.Point(282, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(118, 43);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnShowReport
            // 
            this.btnShowReport.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnShowReport.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnShowReport.Location = new System.Drawing.Point(143, 208);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(118, 43);
            this.btnShowReport.TabIndex = 34;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(158, 157);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(249, 26);
            this.dtpTo.TabIndex = 33;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Location = new System.Drawing.Point(158, 122);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(249, 26);
            this.dtpFrom.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "From Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportLabel
            // 
            this.ReportLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportLabel.Location = new System.Drawing.Point(54, 51);
            this.ReportLabel.Name = "ReportLabel";
            this.ReportLabel.Size = new System.Drawing.Size(409, 23);
            this.ReportLabel.TabIndex = 0;
            this.ReportLabel.Text = "Laebl 1";
            this.ReportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 310);
            this.Controls.Add(this.panel1);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report_Form";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ReportLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnShowReport;
    }
}
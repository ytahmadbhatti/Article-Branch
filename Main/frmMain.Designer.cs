namespace POS.Main
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.codingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partyCodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productCodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeCodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.purToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saleReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reprtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReportBetweenDateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purchaseReturnReportBetweenDateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleReportBetweenDateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patyPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenseCodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.codingToolStripMenuItem,
            this.purchaseToolStripMenuItem,
            this.saleToolStripMenuItem,
            this.toolStripMenuItem1,
            this.reprtToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.newFormsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // codingToolStripMenuItem
            // 
            this.codingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partyCodingToolStripMenuItem,
            this.productCodingToolStripMenuItem,
            this.sizeCodingToolStripMenuItem});
            this.codingToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codingToolStripMenuItem.Name = "codingToolStripMenuItem";
            this.codingToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.codingToolStripMenuItem.Text = "Coding";
            // 
            // partyCodingToolStripMenuItem
            // 
            this.partyCodingToolStripMenuItem.Name = "partyCodingToolStripMenuItem";
            this.partyCodingToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.partyCodingToolStripMenuItem.Text = "Party Coding";
            this.partyCodingToolStripMenuItem.Click += new System.EventHandler(this.partyCodingToolStripMenuItem_Click);
            // 
            // productCodingToolStripMenuItem
            // 
            this.productCodingToolStripMenuItem.Name = "productCodingToolStripMenuItem";
            this.productCodingToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.productCodingToolStripMenuItem.Text = "Article";
            this.productCodingToolStripMenuItem.Click += new System.EventHandler(this.productCodingToolStripMenuItem_Click);
            // 
            // sizeCodingToolStripMenuItem
            // 
            this.sizeCodingToolStripMenuItem.Name = "sizeCodingToolStripMenuItem";
            this.sizeCodingToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.sizeCodingToolStripMenuItem.Text = "Size Coding";
            this.sizeCodingToolStripMenuItem.Visible = false;
            this.sizeCodingToolStripMenuItem.Click += new System.EventHandler(this.sizeCodingToolStripMenuItem_Click);
            // 
            // purchaseToolStripMenuItem
            // 
            this.purchaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseToolStripMenuItem1,
            this.purToolStripMenuItem});
            this.purchaseToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Size = new System.Drawing.Size(90, 25);
            this.purchaseToolStripMenuItem.Text = "Purchase";
            // 
            // purchaseToolStripMenuItem1
            // 
            this.purchaseToolStripMenuItem1.Name = "purchaseToolStripMenuItem1";
            this.purchaseToolStripMenuItem1.Size = new System.Drawing.Size(203, 26);
            this.purchaseToolStripMenuItem1.Text = "Purchase";
            this.purchaseToolStripMenuItem1.Click += new System.EventHandler(this.purchaseToolStripMenuItem1_Click);
            // 
            // purToolStripMenuItem
            // 
            this.purToolStripMenuItem.Name = "purToolStripMenuItem";
            this.purToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.purToolStripMenuItem.Text = "Purchase Return";
            this.purToolStripMenuItem.Click += new System.EventHandler(this.purToolStripMenuItem_Click);
            // 
            // saleToolStripMenuItem
            // 
            this.saleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saleToolStripMenuItem1,
            this.saleReturnToolStripMenuItem});
            this.saleToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.saleToolStripMenuItem.Name = "saleToolStripMenuItem";
            this.saleToolStripMenuItem.Size = new System.Drawing.Size(53, 25);
            this.saleToolStripMenuItem.Text = "Sale";
            // 
            // saleToolStripMenuItem1
            // 
            this.saleToolStripMenuItem1.Name = "saleToolStripMenuItem1";
            this.saleToolStripMenuItem1.Size = new System.Drawing.Size(166, 26);
            this.saleToolStripMenuItem1.Text = "Sale";
            this.saleToolStripMenuItem1.Click += new System.EventHandler(this.saleToolStripMenuItem1_Click);
            // 
            // saleReturnToolStripMenuItem
            // 
            this.saleReturnToolStripMenuItem.Name = "saleReturnToolStripMenuItem";
            this.saleReturnToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.saleReturnToolStripMenuItem.Text = "Sale Return";
            this.saleReturnToolStripMenuItem.Click += new System.EventHandler(this.saleReturnToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 25);
            // 
            // reprtToolStripMenuItem
            // 
            this.reprtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseReportBetweenDateTimeToolStripMenuItem,
            this.purchaseReturnReportBetweenDateTimeToolStripMenuItem,
            this.saleReportBetweenDateTimeToolStripMenuItem});
            this.reprtToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.reprtToolStripMenuItem.Name = "reprtToolStripMenuItem";
            this.reprtToolStripMenuItem.Size = new System.Drawing.Size(74, 25);
            this.reprtToolStripMenuItem.Text = "Report";
            // 
            // purchaseReportBetweenDateTimeToolStripMenuItem
            // 
            this.purchaseReportBetweenDateTimeToolStripMenuItem.Name = "purchaseReportBetweenDateTimeToolStripMenuItem";
            this.purchaseReportBetweenDateTimeToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.purchaseReportBetweenDateTimeToolStripMenuItem.Text = "Purchase Report Between DateTime";
            this.purchaseReportBetweenDateTimeToolStripMenuItem.Click += new System.EventHandler(this.purchaseReportBetweenDateTimeToolStripMenuItem_Click);
            // 
            // purchaseReturnReportBetweenDateTimeToolStripMenuItem
            // 
            this.purchaseReturnReportBetweenDateTimeToolStripMenuItem.Name = "purchaseReturnReportBetweenDateTimeToolStripMenuItem";
            this.purchaseReturnReportBetweenDateTimeToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.purchaseReturnReportBetweenDateTimeToolStripMenuItem.Text = "Purchase Return Report Between DateTime";
            this.purchaseReturnReportBetweenDateTimeToolStripMenuItem.Click += new System.EventHandler(this.purchaseReturnReportBetweenDateTimeToolStripMenuItem_Click);
            // 
            // saleReportBetweenDateTimeToolStripMenuItem
            // 
            this.saleReportBetweenDateTimeToolStripMenuItem.Name = "saleReportBetweenDateTimeToolStripMenuItem";
            this.saleReportBetweenDateTimeToolStripMenuItem.Size = new System.Drawing.Size(404, 26);
            this.saleReportBetweenDateTimeToolStripMenuItem.Text = "Sale Report Between DateTime";
            this.saleReportBetweenDateTimeToolStripMenuItem.Click += new System.EventHandler(this.saleReportBetweenDateTimeToolStripMenuItem_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(77, 25);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(115, 26);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // newFormsToolStripMenuItem
            // 
            this.newFormsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patyPaymentToolStripMenuItem,
            this.expenseToolStripMenuItem,
            this.expenseCodingToolStripMenuItem});
            this.newFormsToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.newFormsToolStripMenuItem.Name = "newFormsToolStripMenuItem";
            this.newFormsToolStripMenuItem.Size = new System.Drawing.Size(110, 25);
            this.newFormsToolStripMenuItem.Text = "New Forms";
            // 
            // patyPaymentToolStripMenuItem
            // 
            this.patyPaymentToolStripMenuItem.Name = "patyPaymentToolStripMenuItem";
            this.patyPaymentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patyPaymentToolStripMenuItem.Text = "Paty payment";
            this.patyPaymentToolStripMenuItem.Click += new System.EventHandler(this.patyPaymentToolStripMenuItem_Click);
            // 
            // expenseToolStripMenuItem
            // 
            this.expenseToolStripMenuItem.Name = "expenseToolStripMenuItem";
            this.expenseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.expenseToolStripMenuItem.Text = "Expense";
            this.expenseToolStripMenuItem.Click += new System.EventHandler(this.expenseToolStripMenuItem_Click);
            // 
            // expenseCodingToolStripMenuItem
            // 
            this.expenseCodingToolStripMenuItem.Name = "expenseCodingToolStripMenuItem";
            this.expenseCodingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.expenseCodingToolStripMenuItem.Text = "Expense Coding";
            this.expenseCodingToolStripMenuItem.Click += new System.EventHandler(this.expenseCodingToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::POS.Properties.Resources.artiom_vallat_CHKaD8uRaDU_unsplash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem codingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partyCodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saleReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productCodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeCodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reprtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseReportBetweenDateTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleReportBetweenDateTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purchaseReturnReportBetweenDateTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFormsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patyPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expenseCodingToolStripMenuItem;
    }
}
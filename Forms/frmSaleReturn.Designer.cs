namespace POS.Forms
{
    partial class frmSaleReturn
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSearchPurchase = new System.Windows.Forms.Label();
            this.dtpInv = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRemainingQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtReturnQuantity = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSalesMan = new System.Windows.Forms.TextBox();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPartyCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaleReturnInv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSaleRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvPurchaseReturn = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtAmount.Location = new System.Drawing.Point(1293, 247);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(293, 24);
            this.txtAmount.TabIndex = 41;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1178, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 21);
            this.label5.TabIndex = 40;
            this.label5.Text = "Total Amount";
            // 
            // lblSearchPurchase
            // 
            this.lblSearchPurchase.AutoSize = true;
            this.lblSearchPurchase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSearchPurchase.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPurchase.Location = new System.Drawing.Point(455, 186);
            this.lblSearchPurchase.Name = "lblSearchPurchase";
            this.lblSearchPurchase.Size = new System.Drawing.Size(139, 14);
            this.lblSearchPurchase.TabIndex = 39;
            this.lblSearchPurchase.Text = "Press F1 To Search Purchase";
            // 
            // dtpInv
            // 
            this.dtpInv.CustomFormat = "dd/MM/yyyy";
            this.dtpInv.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInv.Location = new System.Drawing.Point(861, 198);
            this.dtpInv.Name = "dtpInv";
            this.dtpInv.Size = new System.Drawing.Size(287, 28);
            this.dtpInv.TabIndex = 38;
            this.dtpInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpInv_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(462, 237);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 14);
            this.label14.TabIndex = 35;
            this.label14.Text = "Press F1 To Search Party";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(461, 290);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(134, 14);
            this.label13.TabIndex = 20;
            this.label13.Text = "Press F1 To Search Product";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(63, 463);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 21);
            this.label12.TabIndex = 33;
            this.label12.Text = "Net Amount";
            // 
            // txtRemainingQuantity
            // 
            this.txtRemainingQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemainingQuantity.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtRemainingQuantity.Location = new System.Drawing.Point(458, 544);
            this.txtRemainingQuantity.Multiline = true;
            this.txtRemainingQuantity.Name = "txtRemainingQuantity";
            this.txtRemainingQuantity.ReadOnly = true;
            this.txtRemainingQuantity.Size = new System.Drawing.Size(258, 24);
            this.txtRemainingQuantity.TabIndex = 32;
            this.txtRemainingQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemainingQuantity_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(629, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Purchase";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(89, 353);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 21);
            this.label10.TabIndex = 27;
            this.label10.Text = "Qunatity";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(118, 408);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 21);
            this.label11.TabIndex = 30;
            this.label11.Text = "Rate";
            // 
            // txtReturnQuantity
            // 
            this.txtReturnQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReturnQuantity.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtReturnQuantity.Location = new System.Drawing.Point(458, 496);
            this.txtReturnQuantity.Multiline = true;
            this.txtReturnQuantity.Name = "txtReturnQuantity";
            this.txtReturnQuantity.Size = new System.Drawing.Size(258, 24);
            this.txtReturnQuantity.TabIndex = 29;
            this.txtReturnQuantity.TextChanged += new System.EventHandler(this.txtReturnQuantity_TextChanged_1);
            this.txtReturnQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReturnQuantity_KeyDown);
            this.txtReturnQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReturnQuantity_KeyPress);
            // 
            // txtStock
            // 
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtStock.Location = new System.Drawing.Point(458, 448);
            this.txtStock.Multiline = true;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(258, 24);
            this.txtStock.TabIndex = 28;
            this.txtStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStock_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 21);
            this.label6.TabIndex = 23;
            this.label6.Text = "Product Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(89, 301);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "Product:";
            // 
            // txtSalesMan
            // 
            this.txtSalesMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesMan.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSalesMan.Location = new System.Drawing.Point(1292, 204);
            this.txtSalesMan.Multiline = true;
            this.txtSalesMan.Name = "txtSalesMan";
            this.txtSalesMan.ReadOnly = true;
            this.txtSalesMan.Size = new System.Drawing.Size(293, 24);
            this.txtSalesMan.TabIndex = 11;
            this.txtSalesMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSalesMan_KeyDown);
            // 
            // txtArticle
            // 
            this.txtArticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArticle.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtArticle.Location = new System.Drawing.Point(458, 309);
            this.txtArticle.MaxLength = 10;
            this.txtArticle.Multiline = true;
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(258, 24);
            this.txtArticle.TabIndex = 24;
            this.txtArticle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            this.txtArticle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            // 
            // txtPartyName
            // 
            this.txtPartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyName.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPartyName.Location = new System.Drawing.Point(855, 249);
            this.txtPartyName.Multiline = true;
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.ReadOnly = true;
            this.txtPartyName.Size = new System.Drawing.Size(293, 24);
            this.txtPartyName.TabIndex = 22;
            this.txtPartyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyName_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(755, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 21);
            this.label8.TabIndex = 21;
            this.label8.Text = "Party Name";
            // 
            // txtPartyCode
            // 
            this.txtPartyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyCode.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPartyCode.Location = new System.Drawing.Point(458, 254);
            this.txtPartyCode.MaxLength = 10;
            this.txtPartyCode.Multiline = true;
            this.txtPartyCode.Name = "txtPartyCode";
            this.txtPartyCode.Size = new System.Drawing.Size(258, 24);
            this.txtPartyCode.TabIndex = 20;
            this.txtPartyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyCode_KeyDown);
            this.txtPartyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartyCode_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(67, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 21);
            this.label9.TabIndex = 19;
            this.label9.Text = "Party Code";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(1200, 641);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 47);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(1087, 641);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 47);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(1420, 641);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 47);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1205, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "SalesMan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(777, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "Sale Date";
            // 
            // txtSaleReturnInv
            // 
            this.txtSaleReturnInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaleReturnInv.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSaleReturnInv.Location = new System.Drawing.Point(458, 205);
            this.txtSaleReturnInv.MaxLength = 50;
            this.txtSaleReturnInv.Multiline = true;
            this.txtSaleReturnInv.Name = "txtSaleReturnInv";
            this.txtSaleReturnInv.Size = new System.Drawing.Size(258, 24);
            this.txtSaleReturnInv.TabIndex = 21;
            this.txtSaleReturnInv.TextChanged += new System.EventHandler(this.txtPurchaseReturnInv_TextChanged);
            this.txtSaleReturnInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchaseReturnInv_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-258, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "Purchase Invoice";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(1310, 641);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(104, 47);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.txtNetAmount);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txtSaleRate);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtSaleReturnInv);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblSearchPurchase);
            this.panel1.Controls.Add(this.dtpInv);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dgvPurchaseReturn);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtRemainingQuantity);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtReturnQuantity);
            this.panel1.Controls.Add(this.txtStock);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtSalesMan);
            this.panel1.Controls.Add(this.txtArticle);
            this.panel1.Controls.Add(this.txtPartyName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtPartyCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-285, -111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1624, 783);
            this.panel1.TabIndex = 23;
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtDiscount.Location = new System.Drawing.Point(458, 400);
            this.txtDiscount.Multiline = true;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(258, 24);
            this.txtDiscount.TabIndex = 59;
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(356, 404);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 21);
            this.label19.TabIndex = 58;
            this.label19.Text = "Discount";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(862, 143);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(143, 31);
            this.label25.TabIndex = 56;
            this.label25.Text = "Sale Return";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label23.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(353, 586);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(100, 21);
            this.label23.TabIndex = 53;
            this.label23.Text = "Net Amount";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtNetAmount.Location = new System.Drawing.Point(457, 584);
            this.txtNetAmount.Multiline = true;
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(258, 24);
            this.txtNetAmount.TabIndex = 52;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label22.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(337, 358);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 21);
            this.label22.TabIndex = 51;
            this.label22.Text = "Sale Rate";
            // 
            // txtSaleRate
            // 
            this.txtSaleRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaleRate.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSaleRate.Location = new System.Drawing.Point(457, 356);
            this.txtSaleRate.Multiline = true;
            this.txtSaleRate.Name = "txtSaleRate";
            this.txtSaleRate.Size = new System.Drawing.Size(258, 24);
            this.txtSaleRate.TabIndex = 50;
            this.txtSaleRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSaleRate_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(300, 546);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(156, 21);
            this.label15.TabIndex = 48;
            this.label15.Text = "Remaining Quantity";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(336, 450);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(119, 21);
            this.label16.TabIndex = 46;
            this.label16.Text = "Stock In Hand";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(327, 498);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(128, 21);
            this.label17.TabIndex = 47;
            this.label17.Text = "Quantity Return";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(339, 310);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 21);
            this.label18.TabIndex = 44;
            this.label18.Text = "Article";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(360, 255);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 21);
            this.label20.TabIndex = 43;
            this.label20.Text = "Party Code";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(362, 207);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 21);
            this.label21.TabIndex = 42;
            this.label21.Text = "SR Invoice";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(458, 636);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 47);
            this.btnAdd.TabIndex = 49;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // dgvPurchaseReturn
            // 
            this.dgvPurchaseReturn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchaseReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseReturn.Location = new System.Drawing.Point(729, 290);
            this.dgvPurchaseReturn.Name = "dgvPurchaseReturn";
            this.dgvPurchaseReturn.RowHeadersWidth = 62;
            this.dgvPurchaseReturn.Size = new System.Drawing.Size(870, 330);
            this.dgvPurchaseReturn.TabIndex = 14;
            this.dgvPurchaseReturn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchaseReturn_CellClick);
            // 
            // frmSaleReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 620);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Name = "frmSaleReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Return";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseReturn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSearchPurchase;
        private System.Windows.Forms.DateTimePicker dtpInv;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRemainingQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtReturnQuantity;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSalesMan;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPartyCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaleReturnInv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvPurchaseReturn;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtSaleRate;
    }
}
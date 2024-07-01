namespace POS.Forms
{
    partial class frmPurchase
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtPurchaseInv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSalesMan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvPurchase = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPurchaseRate = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSearchPurchase = new System.Windows.Forms.Label();
            this.dtpInv = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotalPurchase = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPair = new System.Windows.Forms.TextBox();
            this.txtArticle = new System.Windows.Forms.TextBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPartyCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(799, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date";
            // 
            // txtPurchaseInv
            // 
            this.txtPurchaseInv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseInv.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPurchaseInv.Location = new System.Drawing.Point(250, 208);
            this.txtPurchaseInv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseInv.MaxLength = 50;
            this.txtPurchaseInv.Multiline = true;
            this.txtPurchaseInv.Name = "txtPurchaseInv";
            this.txtPurchaseInv.Size = new System.Drawing.Size(386, 36);
            this.txtPurchaseInv.TabIndex = 14;
            this.txtPurchaseInv.TextChanged += new System.EventHandler(this.txtPurchaseInv_TextChanged);
            this.txtPurchaseInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 209);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "Purchase Invoice";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(944, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 47);
            this.label1.TabIndex = 9;
            this.label1.Text = "Purchase";
            // 
            // txtSalesMan
            // 
            this.txtSalesMan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSalesMan.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtSalesMan.Location = new System.Drawing.Point(1520, 222);
            this.txtSalesMan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSalesMan.Multiline = true;
            this.txtSalesMan.Name = "txtSalesMan";
            this.txtSalesMan.ReadOnly = true;
            this.txtSalesMan.Size = new System.Drawing.Size(438, 36);
            this.txtSalesMan.TabIndex = 11;
            this.txtSalesMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocation_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1387, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 33);
            this.label4.TabIndex = 10;
            this.label4.Text = "SalesMan";
            // 
            // dgvPurchase
            // 
            this.dgvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchase.Location = new System.Drawing.Point(675, 365);
            this.dgvPurchase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvPurchase.Name = "dgvPurchase";
            this.dgvPurchase.RowHeadersWidth = 62;
            this.dgvPurchase.Size = new System.Drawing.Size(1305, 508);
            this.dgvPurchase.TabIndex = 14;
            this.dgvPurchase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartyInfo_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(1322, 908);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(156, 72);
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
            this.btnSave.Location = new System.Drawing.Point(1152, 908);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 72);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(1652, 908);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(156, 72);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(1486, 908);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 72);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.txtPurchaseRate);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblSearchPurchase);
            this.panel1.Controls.Add(this.dtpInv);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.dgvPurchase);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtNetAmount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.txtTotalPurchase);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtPair);
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
            this.panel1.Location = new System.Drawing.Point(2, -6);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2055, 1034);
            this.panel1.TabIndex = 19;
            // 
            // txtPurchaseRate
            // 
            this.txtPurchaseRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPurchaseRate.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPurchaseRate.Location = new System.Drawing.Point(248, 525);
            this.txtPurchaseRate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPurchaseRate.Multiline = true;
            this.txtPurchaseRate.Name = "txtPurchaseRate";
            this.txtPurchaseRate.Size = new System.Drawing.Size(386, 36);
            this.txtPurchaseRate.TabIndex = 43;
            this.txtPurchaseRate.TextChanged += new System.EventHandler(this.txtPurchaseRate_TextChanged);
            this.txtPurchaseRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPurchaseRate_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(77, 527);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(182, 33);
            this.label15.TabIndex = 42;
            this.label15.Text = "Purchase Rate \n";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtAmount.Location = new System.Drawing.Point(1521, 289);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmount.MaxLength = 10;
            this.txtAmount.Multiline = true;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(438, 36);
            this.txtAmount.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1345, 292);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 33);
            this.label5.TabIndex = 40;
            this.label5.Text = "Total Amount";
            // 
            // lblSearchPurchase
            // 
            this.lblSearchPurchase.AutoSize = true;
            this.lblSearchPurchase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblSearchPurchase.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchPurchase.Location = new System.Drawing.Point(244, 188);
            this.lblSearchPurchase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchPurchase.Name = "lblSearchPurchase";
            this.lblSearchPurchase.Size = new System.Drawing.Size(206, 19);
            this.lblSearchPurchase.TabIndex = 39;
            this.lblSearchPurchase.Text = "Press F1 To Search Purchase";
            // 
            // dtpInv
            // 
            this.dtpInv.CustomFormat = "dd/MM/yyyy";
            this.dtpInv.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInv.Location = new System.Drawing.Point(873, 211);
            this.dtpInv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpInv.Name = "dtpInv";
            this.dtpInv.Size = new System.Drawing.Size(428, 38);
            this.dtpInv.TabIndex = 38;
            this.dtpInv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpInv_KeyDown_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(254, 265);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(180, 19);
            this.label14.TabIndex = 35;
            this.label14.Text = "Press F1 To Search Party";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(254, 351);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(195, 19);
            this.label13.TabIndex = 20;
            this.label13.Text = "Press F1 To Search Article ";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(231, 912);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 72);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(89, 771);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 33);
            this.label12.TabIndex = 33;
            this.label12.Text = "Net Amount";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNetAmount.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtNetAmount.Location = new System.Drawing.Point(249, 771);
            this.txtNetAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNetAmount.Multiline = true;
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(386, 36);
            this.txtNetAmount.TabIndex = 32;
            this.txtNetAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNetAmount_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(54, 604);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 33);
            this.label10.TabIndex = 27;
            this.label10.Text = "Total Purchase \n";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(118, 687);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 33);
            this.label11.TabIndex = 30;
            this.label11.Text = "Discount ";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtDiscount.Location = new System.Drawing.Point(249, 686);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiscount.Multiline = true;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(386, 36);
            this.txtDiscount.TabIndex = 29;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRate_KeyDown);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // txtTotalPurchase
            // 
            this.txtTotalPurchase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalPurchase.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtTotalPurchase.Location = new System.Drawing.Point(249, 602);
            this.txtTotalPurchase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalPurchase.Multiline = true;
            this.txtTotalPurchase.Name = "txtTotalPurchase";
            this.txtTotalPurchase.ReadOnly = true;
            this.txtTotalPurchase.Size = new System.Drawing.Size(386, 36);
            this.txtTotalPurchase.TabIndex = 28;
            this.txtTotalPurchase.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            this.txtTotalPurchase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantity_KeyDown);
            this.txtTotalPurchase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(143, 377);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 33);
            this.label6.TabIndex = 23;
            this.label6.Text = "Article ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(182, 454);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 33);
            this.label7.TabIndex = 26;
            this.label7.Text = "Pair\n";
            // 
            // txtPair
            // 
            this.txtPair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPair.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPair.Location = new System.Drawing.Point(249, 453);
            this.txtPair.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPair.Multiline = true;
            this.txtPair.Name = "txtPair";
            this.txtPair.Size = new System.Drawing.Size(386, 36);
            this.txtPair.TabIndex = 25;
            this.txtPair.TextChanged += new System.EventHandler(this.txtPair_TextChanged);
            this.txtPair.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPair_KeyDown);
            // 
            // txtArticle
            // 
            this.txtArticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtArticle.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtArticle.Location = new System.Drawing.Point(249, 377);
            this.txtArticle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtArticle.MaxLength = 10;
            this.txtArticle.Multiline = true;
            this.txtArticle.Name = "txtArticle";
            this.txtArticle.Size = new System.Drawing.Size(386, 36);
            this.txtArticle.TabIndex = 24;
            this.txtArticle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArticle_KeyDown_1);
            this.txtArticle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductCode_KeyPress);
            // 
            // txtPartyName
            // 
            this.txtPartyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyName.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPartyName.Location = new System.Drawing.Point(864, 292);
            this.txtPartyName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPartyName.Multiline = true;
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.ReadOnly = true;
            this.txtPartyName.Size = new System.Drawing.Size(438, 36);
            this.txtPartyName.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(710, 294);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 33);
            this.label8.TabIndex = 21;
            this.label8.Text = "Party Name";
            // 
            // txtPartyCode
            // 
            this.txtPartyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartyCode.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPartyCode.Location = new System.Drawing.Point(249, 292);
            this.txtPartyCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPartyCode.MaxLength = 10;
            this.txtPartyCode.Multiline = true;
            this.txtPartyCode.Name = "txtPartyCode";
            this.txtPartyCode.Size = new System.Drawing.Size(386, 36);
            this.txtPartyCode.TabIndex = 1;
            this.txtPartyCode.TextChanged += new System.EventHandler(this.txtPartyCode_TextChanged);
            this.txtPartyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPartyCode_KeyDown_1);
            this.txtPartyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartyCode_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(102, 294);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 33);
            this.label9.TabIndex = 19;
            this.label9.Text = "Party Code";
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1008);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPurchaseInv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Invoice";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPurchaseInv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSalesMan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvPurchase;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPair;
        private System.Windows.Forms.TextBox txtArticle;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPartyCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotalPurchase;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtpInv;
        private System.Windows.Forms.Label lblSearchPurchase;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPurchaseRate;
    }
}
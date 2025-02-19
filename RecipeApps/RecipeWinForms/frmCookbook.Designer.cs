namespace RecipeWinForms
{
    partial class frmCookbook
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
            tblMain = new TableLayoutPanel();
            tblTop = new TableLayoutPanel();
            btnSave = new Button();
            btnDelete = new Button();
            lblCookbookName = new Label();
            lblUser = new Label();
            lblPrice = new Label();
            lblActive = new Label();
            txtCookbookName = new TextBox();
            txtPrice = new TextBox();
            cbActive = new CheckBox();
            lstUserName = new ComboBox();
            lblDateCreated = new Label();
            txtDateCreated = new TextBox();
            tblBottom = new TableLayoutPanel();
            gCookbookRecipes = new DataGridView();
            btnSaveCookbookRecipes = new Button();
            tblMain.SuspendLayout();
            tblTop.SuspendLayout();
            tblBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipes).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(tblTop, 0, 0);
            tblMain.Controls.Add(tblBottom, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(928, 1160);
            tblMain.TabIndex = 0;
            // 
            // tblTop
            // 
            tblTop.ColumnCount = 3;
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tblTop.Controls.Add(btnSave, 0, 0);
            tblTop.Controls.Add(btnDelete, 1, 0);
            tblTop.Controls.Add(lblCookbookName, 0, 1);
            tblTop.Controls.Add(lblUser, 0, 2);
            tblTop.Controls.Add(lblPrice, 0, 4);
            tblTop.Controls.Add(lblActive, 0, 5);
            tblTop.Controls.Add(txtCookbookName, 1, 1);
            tblTop.Controls.Add(txtPrice, 1, 4);
            tblTop.Controls.Add(cbActive, 1, 5);
            tblTop.Controls.Add(lstUserName, 1, 2);
            tblTop.Controls.Add(lblDateCreated, 2, 3);
            tblTop.Controls.Add(txtDateCreated, 2, 4);
            tblTop.Dock = DockStyle.Fill;
            tblTop.Location = new Point(3, 3);
            tblTop.Name = "tblTop";
            tblTop.RowCount = 6;
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tblTop.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tblTop.Size = new Size(922, 574);
            tblTop.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(5, 5);
            btnSave.Margin = new Padding(5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(188, 64);
            btnSave.TabIndex = 10;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(281, 5);
            btnDelete.Margin = new Padding(5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(188, 64);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblCookbookName
            // 
            lblCookbookName.AutoSize = true;
            lblCookbookName.Location = new Point(20, 105);
            lblCookbookName.Margin = new Padding(20, 10, 10, 10);
            lblCookbookName.Name = "lblCookbookName";
            lblCookbookName.Size = new Size(215, 75);
            lblCookbookName.TabIndex = 0;
            lblCookbookName.Text = "Cookbook Name";
            lblCookbookName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(20, 200);
            lblUser.Margin = new Padding(20, 10, 10, 10);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(102, 54);
            lblUser.TabIndex = 2;
            lblUser.Text = "User";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 390);
            lblPrice.Margin = new Padding(20, 10, 10, 10);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(108, 54);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            lblPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Location = new Point(20, 485);
            lblActive.Margin = new Padding(20, 10, 10, 10);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(131, 54);
            lblActive.TabIndex = 8;
            lblActive.Text = "Active";
            lblActive.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCookbookName
            // 
            tblTop.SetColumnSpan(txtCookbookName, 2);
            txtCookbookName.Dock = DockStyle.Fill;
            txtCookbookName.Location = new Point(279, 98);
            txtCookbookName.Name = "txtCookbookName";
            txtCookbookName.Size = new Size(640, 61);
            txtCookbookName.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtPrice.Location = new Point(284, 388);
            txtPrice.Margin = new Padding(8, 8, 3, 3);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(250, 61);
            txtPrice.TabIndex = 5;
            // 
            // cbActive
            // 
            cbActive.AutoSize = true;
            cbActive.Location = new Point(296, 485);
            cbActive.Margin = new Padding(20, 10, 10, 10);
            cbActive.Name = "cbActive";
            cbActive.Size = new Size(34, 33);
            cbActive.TabIndex = 9;
            cbActive.UseVisualStyleBackColor = true;
            // 
            // lstUserName
            // 
            tblTop.SetColumnSpan(lstUserName, 2);
            lstUserName.Dock = DockStyle.Fill;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(279, 193);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(640, 62);
            lstUserName.TabIndex = 3;
            // 
            // lblDateCreated
            // 
            lblDateCreated.AutoSize = true;
            lblDateCreated.Location = new Point(572, 305);
            lblDateCreated.Margin = new Padding(20, 20, 10, 10);
            lblDateCreated.Name = "lblDateCreated";
            lblDateCreated.Size = new Size(256, 54);
            lblDateCreated.TabIndex = 6;
            lblDateCreated.Text = "Date Created";
            // 
            // txtDateCreated
            // 
            txtDateCreated.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtDateCreated.Location = new Point(669, 388);
            txtDateCreated.Margin = new Padding(8, 8, 3, 3);
            txtDateCreated.Name = "txtDateCreated";
            txtDateCreated.Size = new Size(250, 61);
            txtDateCreated.TabIndex = 7;
            // 
            // tblBottom
            // 
            tblBottom.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tblBottom.ColumnCount = 1;
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblBottom.Controls.Add(gCookbookRecipes, 0, 1);
            tblBottom.Controls.Add(btnSaveCookbookRecipes, 0, 0);
            tblBottom.Dock = DockStyle.Fill;
            tblBottom.Location = new Point(3, 583);
            tblBottom.Name = "tblBottom";
            tblBottom.RowCount = 2;
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tblBottom.Size = new Size(922, 574);
            tblBottom.TabIndex = 1;
            // 
            // gCookbookRecipes
            // 
            gCookbookRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbookRecipes.Dock = DockStyle.Fill;
            gCookbookRecipes.Location = new Point(4, 90);
            gCookbookRecipes.Name = "gCookbookRecipes";
            gCookbookRecipes.RowHeadersWidth = 102;
            gCookbookRecipes.Size = new Size(914, 480);
            gCookbookRecipes.TabIndex = 1;
            // 
            // btnSaveCookbookRecipes
            // 
            btnSaveCookbookRecipes.Location = new Point(6, 6);
            btnSaveCookbookRecipes.Margin = new Padding(5);
            btnSaveCookbookRecipes.Name = "btnSaveCookbookRecipes";
            btnSaveCookbookRecipes.Size = new Size(188, 64);
            btnSaveCookbookRecipes.TabIndex = 0;
            btnSaveCookbookRecipes.Text = "S&ave";
            btnSaveCookbookRecipes.UseVisualStyleBackColor = true;
            // 
            // frmCookbook
            // 
            AutoScaleDimensions = new SizeF(22F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 1160);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmCookbook";
            Text = "New Cookbook";
            tblMain.ResumeLayout(false);
            tblTop.ResumeLayout(false);
            tblTop.PerformLayout();
            tblBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblTop;
        private Button btnSave;
        private Button btnDelete;
        private Label lblCookbookName;
        private Label lblUser;
        private Label lblPrice;
        private Label lblActive;
        private TextBox txtCookbookName;
        private TextBox txtPrice;
        private CheckBox cbActive;
        private ComboBox lstUserName;
        private Label lblDateCreated;
        private TextBox txtDateCreated;
        private TableLayoutPanel tblBottom;
        private DataGridView gCookbookRecipes;
        private Button btnSaveCookbookRecipes;
    }
}
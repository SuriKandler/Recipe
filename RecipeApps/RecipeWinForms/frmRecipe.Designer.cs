namespace RecipeWinForms
{
    partial class frmRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipe));
            tblMain = new TableLayoutPanel();
            lblRecipe = new Label();
            lblRecipeStatus = new Label();
            txtCalories = new TextBox();
            lblCalories = new Label();
            lblDateArchived = new Label();
            lblDatePublished = new Label();
            lblDateDraft = new Label();
            txtDatePublished = new TextBox();
            lblCuisine = new Label();
            lblUsersCode = new Label();
            txtDateArchived = new TextBox();
            lstTitle = new ComboBox();
            lstUserName = new ComboBox();
            txtRecipeName = new TextBox();
            txtRecipeStatus = new TextBox();
            dtpDateDraft = new DateTimePicker();
            txMain = new ToolStrip();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tblMain.SuspendLayout();
            txMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblRecipe, 0, 0);
            tblMain.Controls.Add(lblRecipeStatus, 0, 7);
            tblMain.Controls.Add(txtCalories, 1, 6);
            tblMain.Controls.Add(lblCalories, 0, 6);
            tblMain.Controls.Add(lblDateArchived, 0, 5);
            tblMain.Controls.Add(lblDatePublished, 0, 4);
            tblMain.Controls.Add(lblDateDraft, 0, 3);
            tblMain.Controls.Add(txtDatePublished, 1, 4);
            tblMain.Controls.Add(lblCuisine, 0, 2);
            tblMain.Controls.Add(lblUsersCode, 0, 1);
            tblMain.Controls.Add(txtDateArchived, 1, 5);
            tblMain.Controls.Add(lstTitle, 1, 2);
            tblMain.Controls.Add(lstUserName, 1, 1);
            tblMain.Controls.Add(txtRecipeName, 1, 0);
            tblMain.Controls.Add(txtRecipeStatus, 1, 7);
            tblMain.Controls.Add(dtpDateDraft, 1, 3);
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tblMain.Location = new Point(0, 41);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(1064, 585);
            tblMain.TabIndex = 0;
            // 
            // lblRecipe
            // 
            lblRecipe.Anchor = AnchorStyles.Left;
            lblRecipe.AutoSize = true;
            lblRecipe.Location = new Point(3, 9);
            lblRecipe.Name = "lblRecipe";
            lblRecipe.Size = new Size(102, 21);
            lblRecipe.TabIndex = 0;
            lblRecipe.Text = "Recipe Name";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(3, 300);
            lblRecipeStatus.Margin = new Padding(3, 7, 3, 0);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(102, 21);
            lblRecipeStatus.TabIndex = 6;
            lblRecipeStatus.Text = "Recipe Status";
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(123, 243);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(938, 29);
            txtCalories.TabIndex = 17;
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(3, 256);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(66, 21);
            lblCalories.TabIndex = 5;
            lblCalories.Text = "Calories";
            // 
            // lblDateArchived
            // 
            lblDateArchived.Anchor = AnchorStyles.Left;
            lblDateArchived.AutoSize = true;
            lblDateArchived.Location = new Point(3, 209);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(107, 21);
            lblDateArchived.TabIndex = 4;
            lblDateArchived.Text = "Date Archived";
            // 
            // lblDatePublished
            // 
            lblDatePublished.Anchor = AnchorStyles.Left;
            lblDatePublished.AutoSize = true;
            lblDatePublished.Location = new Point(3, 169);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(114, 21);
            lblDatePublished.TabIndex = 3;
            lblDatePublished.Text = "Date Published";
            // 
            // lblDateDraft
            // 
            lblDateDraft.Anchor = AnchorStyles.Left;
            lblDateDraft.AutoSize = true;
            lblDateDraft.Location = new Point(3, 129);
            lblDateDraft.Name = "lblDateDraft";
            lblDateDraft.Size = new Size(81, 21);
            lblDateDraft.TabIndex = 2;
            lblDateDraft.Text = "Date Draft";
            // 
            // txtDatePublished
            // 
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Location = new Point(123, 163);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(938, 29);
            txtDatePublished.TabIndex = 15;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Location = new Point(3, 89);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(61, 21);
            lblCuisine.TabIndex = 20;
            lblCuisine.Text = "Cuisine";
            // 
            // lblUsersCode
            // 
            lblUsersCode.Anchor = AnchorStyles.Left;
            lblUsersCode.AutoSize = true;
            lblUsersCode.Location = new Point(3, 49);
            lblUsersCode.Name = "lblUsersCode";
            lblUsersCode.Size = new Size(89, 21);
            lblUsersCode.TabIndex = 19;
            lblUsersCode.Text = "Users Code";
            // 
            // txtDateArchived
            // 
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Location = new Point(123, 203);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(938, 29);
            txtDateArchived.TabIndex = 23;
            // 
            // lstTitle
            // 
            lstTitle.FormattingEnabled = true;
            lstTitle.Location = new Point(123, 83);
            lstTitle.Name = "lstTitle";
            lstTitle.Size = new Size(252, 29);
            lstTitle.TabIndex = 24;
            // 
            // lstUserName
            // 
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(123, 43);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(252, 29);
            lstUserName.TabIndex = 25;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(123, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(938, 29);
            txtRecipeName.TabIndex = 26;
            // 
            // txtRecipeStatus
            // 
            txtRecipeStatus.Dock = DockStyle.Fill;
            txtRecipeStatus.Location = new Point(123, 296);
            txtRecipeStatus.Name = "txtRecipeStatus";
            txtRecipeStatus.Size = new Size(938, 29);
            txtRecipeStatus.TabIndex = 27;
            // 
            // dtpDateDraft
            // 
            dtpDateDraft.Location = new Point(123, 123);
            dtpDateDraft.Name = "dtpDateDraft";
            dtpDateDraft.Size = new Size(200, 29);
            dtpDateDraft.TabIndex = 28;
            // 
            // txMain
            // 
            txMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txMain.Items.AddRange(new ToolStripItem[] { btnSave, toolStripSeparator1, btnDelete, toolStripSeparator2 });
            txMain.Location = new Point(0, 0);
            txMain.Name = "txMain";
            txMain.Size = new Size(1064, 28);
            txMain.TabIndex = 1;
            txMain.Text = "toolStrip1";
            // 
            // btnSave
            // 
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(47, 25);
            btnSave.Text = "&Save";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 28);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(58, 25);
            btnDelete.Text = "&Delete";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 623);
            Controls.Add(txMain);
            Controls.Add(tblMain);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            txMain.ResumeLayout(false);
            txMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblUser;
        private Label lblDateDraft;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private Label lblCalories;
        private Label lblRecipeStatus;
        private Label lblRecipe;
        private Label lblUserName;
        private Label label6;
        private TextBox txtDatePublished;
        private ToolStrip txMain;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDelete;
        private ToolStripSeparator toolStripSeparator2;
        private TextBox txtCalories;
        private Label lblCuisine;
        private Label lblUsersCode;
        private TextBox txtDateArchived;
        private ComboBox lstCuisine;
        private ComboBox lstUsersCode;
        private ComboBox lstTitle;
        private ComboBox lstUserName;
        private TextBox txtRecipeName;
        private TextBox txtRecipeStatus;
        private DateTimePicker dtpDateDraft;
    }
}
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
            tblMain = new TableLayoutPanel();
            lblDatePublished = new Label();
            lblDateArchived = new Label();
            lblCalories = new Label();
            lblRecipe = new Label();
            lblStatus = new Label();
            txtDateDraft = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            lblCaloriesAmount = new Label();
            lblRecipeName = new Label();
            lblDateDraft = new Label();
            lblRecipeStatus = new Label();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblDatePublished, 0, 2);
            tblMain.Controls.Add(lblDateArchived, 0, 3);
            tblMain.Controls.Add(lblCalories, 0, 4);
            tblMain.Controls.Add(lblRecipe, 1, 0);
            tblMain.Controls.Add(lblStatus, 1, 5);
            tblMain.Controls.Add(txtDateDraft, 1, 1);
            tblMain.Controls.Add(txtDatePublished, 1, 2);
            tblMain.Controls.Add(txtDateArchived, 1, 3);
            tblMain.Controls.Add(lblCaloriesAmount, 1, 4);
            tblMain.Controls.Add(lblRecipeName, 0, 0);
            tblMain.Controls.Add(lblDateDraft, 0, 1);
            tblMain.Controls.Add(lblRecipeStatus, 0, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 6;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(1064, 623);
            tblMain.TabIndex = 0;
            // 
            // lblDatePublished
            // 
            lblDatePublished.Anchor = AnchorStyles.Left;
            lblDatePublished.AutoSize = true;
            lblDatePublished.Location = new Point(3, 89);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(114, 21);
            lblDatePublished.TabIndex = 3;
            lblDatePublished.Text = "Date Published";
            // 
            // lblDateArchived
            // 
            lblDateArchived.Anchor = AnchorStyles.Left;
            lblDateArchived.AutoSize = true;
            lblDateArchived.Location = new Point(3, 129);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(107, 21);
            lblDateArchived.TabIndex = 4;
            lblDateArchived.Text = "Date Archived";
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(3, 169);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(66, 21);
            lblCalories.TabIndex = 5;
            lblCalories.Text = "Calories";
            // 
            // lblRecipe
            // 
            lblRecipe.BackColor = Color.WhiteSmoke;
            lblRecipe.BorderStyle = BorderStyle.FixedSingle;
            lblRecipe.Dock = DockStyle.Fill;
            lblRecipe.Location = new Point(123, 0);
            lblRecipe.Name = "lblRecipe";
            lblRecipe.Size = new Size(938, 40);
            lblRecipe.TabIndex = 7;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.WhiteSmoke;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(123, 200);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(938, 37);
            lblStatus.TabIndex = 13;
            // 
            // txtDateDraft
            // 
            txtDateDraft.Dock = DockStyle.Fill;
            txtDateDraft.Location = new Point(123, 43);
            txtDateDraft.Name = "txtDateDraft";
            txtDateDraft.Size = new Size(938, 29);
            txtDateDraft.TabIndex = 14;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Location = new Point(123, 83);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(938, 29);
            txtDatePublished.TabIndex = 15;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Location = new Point(123, 123);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(938, 29);
            txtDateArchived.TabIndex = 16;
            // 
            // lblCaloriesAmount
            // 
            lblCaloriesAmount.AutoSize = true;
            lblCaloriesAmount.BackColor = Color.WhiteSmoke;
            lblCaloriesAmount.BorderStyle = BorderStyle.FixedSingle;
            lblCaloriesAmount.Dock = DockStyle.Fill;
            lblCaloriesAmount.Location = new Point(123, 160);
            lblCaloriesAmount.Name = "lblCaloriesAmount";
            lblCaloriesAmount.Size = new Size(938, 40);
            lblCaloriesAmount.TabIndex = 17;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 9);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(102, 21);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            // 
            // lblDateDraft
            // 
            lblDateDraft.Anchor = AnchorStyles.Left;
            lblDateDraft.AutoSize = true;
            lblDateDraft.Location = new Point(3, 49);
            lblDateDraft.Name = "lblDateDraft";
            lblDateDraft.Size = new Size(81, 21);
            lblDateDraft.TabIndex = 2;
            lblDateDraft.Text = "Date Draft";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Location = new Point(3, 207);
            lblRecipeStatus.Margin = new Padding(3, 7, 3, 0);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(102, 21);
            lblRecipeStatus.TabIndex = 6;
            lblRecipeStatus.Text = "Recipe Status";
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 623);
            Controls.Add(tblMain);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipeName;
        private Label lblUser;
        private Label lblDateDraft;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private Label lblCalories;
        private Label lblRecipeStatus;
        private Label lblRecipe;
        private Label lblUserName;
        private Label label6;
        private Label lblStatus;
        private TextBox txtDateDraft;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private Label lblCaloriesAmount;
    }
}
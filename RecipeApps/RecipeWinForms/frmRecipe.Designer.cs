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
            lblStatus = new Label();
            txtCalories = new TextBox();
            lblCalories = new Label();
            lblCuisine = new Label();
            lblUsersCode = new Label();
            lstTitle = new ComboBox();
            lstUserName = new ComboBox();
            lblRecipe = new Label();
            txtRecipeName = new TextBox();
            tlpButtons = new TableLayoutPanel();
            btnChangeStatus = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            tlpDatesLabel = new TableLayoutPanel();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblDateDraft = new Label();
            lblDatePublished = new Label();
            lblDateArchived = new Label();
            lblStatusDates = new Label();
            tbChildRecords = new TabControl();
            tbIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredient = new Button();
            gIngredients = new DataGridView();
            tbSteps = new TabPage();
            tblSteps = new TableLayoutPanel();
            btnSaveSteps = new Button();
            gSteps = new DataGridView();
            lblRecipeStatus = new Label();
            tblMain.SuspendLayout();
            tlpButtons.SuspendLayout();
            tlpDatesLabel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tbChildRecords.SuspendLayout();
            tbIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).BeginInit();
            tbSteps.SuspendLayout();
            tblSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblStatus, 0, 5);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(lblCalories, 0, 4);
            tblMain.Controls.Add(lblCuisine, 0, 3);
            tblMain.Controls.Add(lblUsersCode, 0, 2);
            tblMain.Controls.Add(lstTitle, 1, 3);
            tblMain.Controls.Add(lstUserName, 1, 2);
            tblMain.Controls.Add(lblRecipe, 0, 1);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(tlpButtons, 0, 0);
            tblMain.Controls.Add(tlpDatesLabel, 1, 6);
            tblMain.Controls.Add(tableLayoutPanel1, 1, 7);
            tblMain.Controls.Add(lblStatusDates, 0, 7);
            tblMain.Controls.Add(tbChildRecords, 0, 8);
            tblMain.Controls.Add(lblRecipeStatus, 1, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(7, 8, 7, 8);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1942, 1472);
            tblMain.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(7, 406);
            lblStatus.Margin = new Padding(7, 19, 7, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(276, 54);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Current Status";
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(297, 318);
            txtCalories.Margin = new Padding(7, 8, 7, 8);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(1638, 61);
            txtCalories.TabIndex = 7;
            // 
            // lblCalories
            // 
            lblCalories.Anchor = AnchorStyles.Left;
            lblCalories.AutoSize = true;
            lblCalories.Location = new Point(7, 321);
            lblCalories.Margin = new Padding(7, 0, 7, 0);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(261, 54);
            lblCalories.TabIndex = 6;
            lblCalories.Text = "Num Calories";
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Location = new Point(7, 244);
            lblCuisine.Margin = new Padding(7, 0, 7, 0);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(152, 54);
            lblCuisine.TabIndex = 4;
            lblCuisine.Text = "Cuisine";
            // 
            // lblUsersCode
            // 
            lblUsersCode.Anchor = AnchorStyles.Left;
            lblUsersCode.AutoSize = true;
            lblUsersCode.Location = new Point(7, 166);
            lblUsersCode.Margin = new Padding(7, 0, 7, 0);
            lblUsersCode.Name = "lblUsersCode";
            lblUsersCode.Size = new Size(102, 54);
            lblUsersCode.TabIndex = 2;
            lblUsersCode.Text = "User";
            // 
            // lstTitle
            // 
            lstTitle.FormattingEnabled = true;
            lstTitle.Location = new Point(297, 240);
            lstTitle.Margin = new Padding(7, 8, 7, 8);
            lstTitle.Name = "lstTitle";
            lstTitle.Size = new Size(606, 62);
            lstTitle.TabIndex = 5;
            // 
            // lstUserName
            // 
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(297, 162);
            lstUserName.Margin = new Padding(7, 8, 7, 8);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(606, 62);
            lstUserName.TabIndex = 3;
            // 
            // lblRecipe
            // 
            lblRecipe.Anchor = AnchorStyles.Left;
            lblRecipe.AutoSize = true;
            lblRecipe.Location = new Point(7, 93);
            lblRecipe.Margin = new Padding(7, 0, 7, 0);
            lblRecipe.Name = "lblRecipe";
            lblRecipe.Size = new Size(256, 54);
            lblRecipe.TabIndex = 0;
            lblRecipe.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(293, 90);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(1646, 61);
            txtRecipeName.TabIndex = 1;
            // 
            // tlpButtons
            // 
            tlpButtons.ColumnCount = 4;
            tblMain.SetColumnSpan(tlpButtons, 2);
            tlpButtons.ColumnStyles.Add(new ColumnStyle());
            tlpButtons.ColumnStyles.Add(new ColumnStyle());
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 406F));
            tlpButtons.Controls.Add(btnChangeStatus, 3, 0);
            tlpButtons.Controls.Add(btnDelete, 2, 0);
            tlpButtons.Controls.Add(btnSave, 0, 0);
            tlpButtons.Dock = DockStyle.Fill;
            tlpButtons.Location = new Point(3, 3);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.Size = new Size(1936, 81);
            tlpButtons.TabIndex = 35;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Location = new Point(1533, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(400, 75);
            btnChangeStatus.TabIndex = 2;
            btnChangeStatus.Text = "&Change Status";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(293, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(293, 75);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(284, 75);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // tlpDatesLabel
            // 
            tlpDatesLabel.ColumnCount = 3;
            tlpDatesLabel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlpDatesLabel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpDatesLabel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tlpDatesLabel.Controls.Add(lblDrafted, 0, 0);
            tlpDatesLabel.Controls.Add(lblPublished, 1, 0);
            tlpDatesLabel.Controls.Add(lblArchived, 2, 0);
            tlpDatesLabel.Dock = DockStyle.Fill;
            tlpDatesLabel.Location = new Point(293, 463);
            tlpDatesLabel.Name = "tlpDatesLabel";
            tlpDatesLabel.RowCount = 1;
            tlpDatesLabel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpDatesLabel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpDatesLabel.Size = new Size(1646, 55);
            tlpDatesLabel.TabIndex = 36;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Location = new Point(3, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(542, 55);
            lblDrafted.TabIndex = 0;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(551, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(542, 55);
            lblPublished.TabIndex = 1;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(1099, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(544, 55);
            lblArchived.TabIndex = 2;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(lblDateDraft, 0, 0);
            tableLayoutPanel1.Controls.Add(lblDatePublished, 1, 0);
            tableLayoutPanel1.Controls.Add(lblDateArchived, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(293, 524);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1646, 81);
            tableLayoutPanel1.TabIndex = 37;
            // 
            // lblDateDraft
            // 
            lblDateDraft.AutoSize = true;
            lblDateDraft.BackColor = SystemColors.ActiveBorder;
            lblDateDraft.Dock = DockStyle.Fill;
            lblDateDraft.Location = new Point(3, 0);
            lblDateDraft.Name = "lblDateDraft";
            lblDateDraft.Size = new Size(542, 81);
            lblDateDraft.TabIndex = 3;
            lblDateDraft.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDatePublished
            // 
            lblDatePublished.AutoSize = true;
            lblDatePublished.BackColor = SystemColors.ActiveBorder;
            lblDatePublished.Dock = DockStyle.Fill;
            lblDatePublished.Location = new Point(551, 0);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(542, 81);
            lblDatePublished.TabIndex = 4;
            lblDatePublished.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDateArchived
            // 
            lblDateArchived.AutoSize = true;
            lblDateArchived.BackColor = SystemColors.ActiveBorder;
            lblDateArchived.Dock = DockStyle.Fill;
            lblDateArchived.Location = new Point(1099, 0);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(544, 81);
            lblDateArchived.TabIndex = 5;
            lblDateArchived.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStatusDates
            // 
            lblStatusDates.AutoSize = true;
            lblStatusDates.Location = new Point(7, 521);
            lblStatusDates.Margin = new Padding(7, 0, 7, 0);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(242, 54);
            lblStatusDates.TabIndex = 10;
            lblStatusDates.Text = "Status Dates";
            // 
            // tbChildRecords
            // 
            tblMain.SetColumnSpan(tbChildRecords, 2);
            tbChildRecords.Controls.Add(tbIngredients);
            tbChildRecords.Controls.Add(tbSteps);
            tbChildRecords.Dock = DockStyle.Fill;
            tbChildRecords.Location = new Point(3, 611);
            tbChildRecords.Name = "tbChildRecords";
            tbChildRecords.SelectedIndex = 0;
            tbChildRecords.Size = new Size(1936, 858);
            tbChildRecords.TabIndex = 12;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(10, 71);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(3);
            tbIngredients.Size = new Size(1916, 777);
            tbIngredients.TabIndex = 0;
            tbIngredients.Text = "Ingredients";
            tbIngredients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle());
            tblIngredients.Controls.Add(btnSaveIngredient, 0, 0);
            tblIngredients.Controls.Add(gIngredients, 0, 1);
            tblIngredients.Dock = DockStyle.Fill;
            tblIngredients.Location = new Point(3, 3);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle());
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblIngredients.Size = new Size(1910, 771);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredient
            // 
            btnSaveIngredient.AutoSize = true;
            btnSaveIngredient.Location = new Point(3, 3);
            btnSaveIngredient.Name = "btnSaveIngredient";
            btnSaveIngredient.Size = new Size(188, 64);
            btnSaveIngredient.TabIndex = 0;
            btnSaveIngredient.Text = "Save";
            btnSaveIngredient.UseVisualStyleBackColor = true;
            // 
            // gIngredients
            // 
            gIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredients.Dock = DockStyle.Fill;
            gIngredients.Location = new Point(3, 73);
            gIngredients.Name = "gIngredients";
            gIngredients.RowHeadersWidth = 102;
            gIngredients.Size = new Size(1904, 695);
            gIngredients.TabIndex = 1;
            // 
            // tbSteps
            // 
            tbSteps.Controls.Add(tblSteps);
            tbSteps.Location = new Point(10, 71);
            tbSteps.Name = "tbSteps";
            tbSteps.Padding = new Padding(3);
            tbSteps.Size = new Size(1916, 803);
            tbSteps.TabIndex = 1;
            tbSteps.Text = "Steps";
            tbSteps.UseVisualStyleBackColor = true;
            // 
            // tblSteps
            // 
            tblSteps.ColumnCount = 1;
            tblSteps.ColumnStyles.Add(new ColumnStyle());
            tblSteps.Controls.Add(btnSaveSteps, 0, 0);
            tblSteps.Controls.Add(gSteps, 0, 1);
            tblSteps.Dock = DockStyle.Fill;
            tblSteps.Location = new Point(3, 3);
            tblSteps.Name = "tblSteps";
            tblSteps.RowCount = 2;
            tblSteps.RowStyles.Add(new RowStyle());
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSteps.Size = new Size(1910, 797);
            tblSteps.TabIndex = 0;
            // 
            // btnSaveSteps
            // 
            btnSaveSteps.Location = new Point(3, 3);
            btnSaveSteps.Name = "btnSaveSteps";
            btnSaveSteps.Size = new Size(188, 58);
            btnSaveSteps.TabIndex = 0;
            btnSaveSteps.Text = "Save";
            btnSaveSteps.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(3, 67);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 102;
            gSteps.Size = new Size(1904, 727);
            gSteps.TabIndex = 1;
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.BackColor = SystemColors.ActiveBorder;
            lblRecipeStatus.Dock = DockStyle.Fill;
            lblRecipeStatus.Location = new Point(293, 387);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(1646, 73);
            lblRecipeStatus.TabIndex = 38;
            lblRecipeStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1942, 1472);
            Controls.Add(tblMain);
            Margin = new Padding(7, 8, 7, 8);
            Name = "frmRecipe";
            Text = "Recipe";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tlpButtons.ResumeLayout(false);
            tlpDatesLabel.ResumeLayout(false);
            tlpDatesLabel.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tbChildRecords.ResumeLayout(false);
            tbIngredients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            tblIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredients).EndInit();
            tbSteps.ResumeLayout(false);
            tblSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gSteps).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblCalories;
        private Label lblRecipe;
        private Label lblUsersCode;
        private ComboBox lstTitle;
        private ComboBox lstUserName;
        private Button btnSave;
        private Button btnDelete;
        private Label lblStatus;
        private TextBox txtCalories;
        private Label lblCuisine;
        private TextBox txtRecipeName;
        private TableLayoutPanel tlpButtons;
        private TableLayoutPanel tlpDatesLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblStatusDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TabControl tbChildRecords;
        private TabPage tbIngredients;
        private TabPage tbSteps;
        private TableLayoutPanel tblIngredients;
        private Button btnSaveIngredient;
        private DataGridView gIngredients;
        private TableLayoutPanel tblSteps;
        private Button btnSaveSteps;
        private DataGridView gSteps;
        private Label lblRecipeStatus;
        private Label lblDateDraft;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private Button btnChangeStatus;
    }
}
namespace RecipeWinForms
{
    partial class frmChangeStatus
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
            tblButtons = new TableLayoutPanel();
            btnDraft = new Button();
            btnPublish = new Button();
            btnArchive = new Button();
            lblRecipeName = new Label();
            lblCurrentStatusTitle = new Label();
            lblRecipeStatus = new Label();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            lblStatusDates = new Label();
            txtDateDraft = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            tblMain.SuspendLayout();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblMain.ColumnCount = 6;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tblMain.Controls.Add(tblButtons, 1, 4);
            tblMain.Controls.Add(lblRecipeName, 2, 0);
            tblMain.Controls.Add(lblCurrentStatusTitle, 2, 1);
            tblMain.Controls.Add(lblRecipeStatus, 3, 1);
            tblMain.Controls.Add(lblDrafted, 2, 2);
            tblMain.Controls.Add(lblPublished, 3, 2);
            tblMain.Controls.Add(lblArchived, 4, 2);
            tblMain.Controls.Add(lblStatusDates, 1, 3);
            tblMain.Controls.Add(txtDateDraft, 2, 3);
            tblMain.Controls.Add(txtDatePublished, 3, 3);
            tblMain.Controls.Add(txtDateArchived, 4, 3);
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 5;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tblMain.Size = new Size(1767, 921);
            tblMain.TabIndex = 0;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 5;
            tblMain.SetColumnSpan(tblButtons, 4);
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tblButtons.Controls.Add(btnDraft, 1, 1);
            tblButtons.Controls.Add(btnPublish, 2, 1);
            tblButtons.Controls.Add(btnArchive, 3, 1);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(92, 556);
            tblButtons.Margin = new Padding(4);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 3;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 66.66667F));
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tblButtons.Size = new Size(1404, 361);
            tblButtons.TabIndex = 0;
            // 
            // btnDraft
            // 
            btnDraft.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDraft.Location = new Point(74, 64);
            btnDraft.Margin = new Padding(4);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(413, 76);
            btnDraft.TabIndex = 0;
            btnDraft.Text = "Draft";
            btnDraft.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            btnPublish.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPublish.Location = new Point(495, 64);
            btnPublish.Margin = new Padding(4);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(413, 76);
            btnPublish.TabIndex = 1;
            btnPublish.Text = "Publish";
            btnPublish.UseVisualStyleBackColor = true;
            // 
            // btnArchive
            // 
            btnArchive.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnArchive.Location = new Point(916, 64);
            btnArchive.Margin = new Padding(4);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(413, 76);
            btnArchive.TabIndex = 2;
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = true;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            tblMain.SetColumnSpan(lblRecipeName, 4);
            lblRecipeName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecipeName.Location = new Point(445, 30);
            lblRecipeName.Margin = new Padding(4, 30, 4, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(0, 81);
            lblRecipeName.TabIndex = 1;
            lblRecipeName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatusTitle
            // 
            lblCurrentStatusTitle.AutoSize = true;
            lblCurrentStatusTitle.Location = new Point(444, 168);
            lblCurrentStatusTitle.Margin = new Padding(3, 30, 3, 0);
            lblCurrentStatusTitle.Name = "lblCurrentStatusTitle";
            lblCurrentStatusTitle.Size = new Size(285, 54);
            lblCurrentStatusTitle.TabIndex = 2;
            lblCurrentStatusTitle.Text = "Current Status:";
            // 
            // lblRecipeStatus
            // 
            lblRecipeStatus.AutoSize = true;
            lblRecipeStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecipeStatus.Location = new Point(797, 168);
            lblRecipeStatus.Margin = new Padding(3, 30, 3, 0);
            lblRecipeStatus.Name = "lblRecipeStatus";
            lblRecipeStatus.Size = new Size(0, 54);
            lblRecipeStatus.TabIndex = 3;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Location = new Point(444, 306);
            lblDrafted.Margin = new Padding(3, 30, 3, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(157, 54);
            lblDrafted.TabIndex = 4;
            lblDrafted.Text = "Drafted";
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Location = new Point(797, 306);
            lblPublished.Margin = new Padding(3, 30, 3, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(197, 54);
            lblPublished.TabIndex = 5;
            lblPublished.Text = "Published";
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Location = new Point(1150, 306);
            lblArchived.Margin = new Padding(3, 30, 3, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(178, 54);
            lblArchived.TabIndex = 6;
            lblArchived.Text = "Archived";
            // 
            // lblStatusDates
            // 
            lblStatusDates.AutoSize = true;
            lblStatusDates.Location = new Point(91, 408);
            lblStatusDates.Margin = new Padding(3, 40, 3, 0);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(242, 54);
            lblStatusDates.TabIndex = 7;
            lblStatusDates.Text = "Status Dates";
            // 
            // txtDateDraft
            // 
            txtDateDraft.Dock = DockStyle.Fill;
            txtDateDraft.Location = new Point(444, 408);
            txtDateDraft.Margin = new Padding(3, 40, 3, 3);
            txtDateDraft.Name = "txtDateDraft";
            txtDateDraft.Size = new Size(347, 61);
            txtDateDraft.TabIndex = 8;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Dock = DockStyle.Fill;
            txtDatePublished.Location = new Point(797, 408);
            txtDatePublished.Margin = new Padding(3, 40, 3, 3);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(347, 61);
            txtDatePublished.TabIndex = 9;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Dock = DockStyle.Fill;
            txtDateArchived.Location = new Point(1150, 408);
            txtDateArchived.Margin = new Padding(3, 40, 3, 3);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(347, 61);
            txtDateArchived.TabIndex = 10;
            // 
            // frmChangeStatus
            // 
            AutoScaleDimensions = new SizeF(22F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1767, 921);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmChangeStatus";
            Text = "Change Status";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblButtons;
        private Button btnDraft;
        private Button btnPublish;
        private Button btnArchive;
        private Label lblRecipeName;
        private Label lblCurrentStatusTitle;
        private Label lblRecipeStatus;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private Label lblStatusDates;
        private TextBox txtDateDraft;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
    }
}
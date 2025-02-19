namespace RecipeWinForms
{
    partial class frmDashboard
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tblMain = new TableLayoutPanel();
            tblButtons = new TableLayoutPanel();
            btnRecipeList = new Button();
            btnMealList = new Button();
            btnCookbookList = new Button();
            lblDescription = new Label();
            lblHeartyHearth = new Label();
            gTotalList = new DataGridView();
            tblMain.SuspendLayout();
            tblButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gTotalList).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.75F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.5F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.75F));
            tblMain.Controls.Add(tblButtons, 1, 4);
            tblMain.Controls.Add(lblDescription, 1, 2);
            tblMain.Controls.Add(lblHeartyHearth, 1, 1);
            tblMain.Controls.Add(gTotalList, 1, 3);
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(20);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 6;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 4.5454545F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 18.181818F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 18.181818F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 36.363636F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 18.181818F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 4.5454545F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(1180, 1003);
            tblMain.TabIndex = 0;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.4638786F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.26616F));
            tblButtons.Controls.Add(btnRecipeList, 0, 0);
            tblButtons.Controls.Add(btnMealList, 1, 0);
            tblButtons.Controls.Add(btnCookbookList, 2, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(225, 777);
            tblButtons.Margin = new Padding(4);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(729, 174);
            tblButtons.TabIndex = 4;
            // 
            // btnRecipeList
            // 
            btnRecipeList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRecipeList.AutoSize = true;
            btnRecipeList.Location = new Point(20, 20);
            btnRecipeList.Margin = new Padding(20);
            btnRecipeList.Name = "btnRecipeList";
            btnRecipeList.Size = new Size(202, 134);
            btnRecipeList.TabIndex = 0;
            btnRecipeList.Text = "Recipe List";
            btnRecipeList.UseVisualStyleBackColor = true;
            // 
            // btnMealList
            // 
            btnMealList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnMealList.AutoSize = true;
            btnMealList.Location = new Point(262, 20);
            btnMealList.Margin = new Padding(20);
            btnMealList.Name = "btnMealList";
            btnMealList.Size = new Size(189, 134);
            btnMealList.TabIndex = 1;
            btnMealList.Text = "Meal List";
            btnMealList.UseVisualStyleBackColor = true;
            // 
            // btnCookbookList
            // 
            btnCookbookList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnCookbookList.AutoSize = true;
            btnCookbookList.Location = new Point(491, 20);
            btnCookbookList.Margin = new Padding(20);
            btnCookbookList.Name = "btnCookbookList";
            btnCookbookList.Size = new Size(218, 134);
            btnCookbookList.TabIndex = 2;
            btnCookbookList.Text = "Cookbook List";
            btnCookbookList.UseVisualStyleBackColor = true;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(231, 237);
            lblDescription.Margin = new Padding(10, 10, 15, 10);
            lblDescription.Name = "lblDescription";
            lblDescription.RightToLeft = RightToLeft.No;
            lblDescription.Size = new Size(712, 162);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Welcome to Hearty Herth Desktop app.  In this app you can create recipes and cookbooks. As well as manage data.";
            lblDescription.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeartyHearth
            // 
            lblHeartyHearth.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblHeartyHearth.AutoSize = true;
            lblHeartyHearth.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeartyHearth.Location = new Point(231, 55);
            lblHeartyHearth.Margin = new Padding(10);
            lblHeartyHearth.Name = "lblHeartyHearth";
            lblHeartyHearth.Size = new Size(717, 162);
            lblHeartyHearth.TabIndex = 0;
            lblHeartyHearth.Text = "Hearty Hearth Desktop App";
            lblHeartyHearth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gTotalList
            // 
            gTotalList.AllowUserToAddRows = false;
            gTotalList.AllowUserToDeleteRows = false;
            gTotalList.AllowUserToResizeColumns = false;
            gTotalList.AllowUserToResizeRows = false;
            gTotalList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gTotalList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gTotalList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gTotalList.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gTotalList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gTotalList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gTotalList.EditMode = DataGridViewEditMode.EditProgrammatically;
            gTotalList.Location = new Point(224, 412);
            gTotalList.MultiSelect = false;
            gTotalList.Name = "gTotalList";
            gTotalList.ReadOnly = true;
            gTotalList.RowHeadersVisible = false;
            gTotalList.RowHeadersWidth = 102;
            gTotalList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gTotalList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            gTotalList.RowTemplate.Height = 60;
            gTotalList.RowTemplate.ReadOnly = true;
            gTotalList.RowTemplate.Resizable = DataGridViewTriState.False;
            gTotalList.ScrollBars = ScrollBars.None;
            gTotalList.Size = new Size(731, 358);
            gTotalList.TabIndex = 5;
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(22F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 1003);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmDashboard";
            Text = "Dashboard";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            tblButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gTotalList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblHeartyHearth;
        private Label lblDescription;
        private TableLayoutPanel tblButtons;
        private Button btnRecipeList;
        private Button btnMealList;
        private Button btnCookbookList;
        private DataGridView gTotalList;
    }
}
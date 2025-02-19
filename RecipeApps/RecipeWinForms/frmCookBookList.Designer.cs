namespace RecipeWinForms
{
    partial class frmCookbookList
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
            gCookbookList = new DataGridView();
            btnNewCookbook = new Button();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookList).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tblMain.Controls.Add(gCookbookList, 1, 2);
            tblMain.Controls.Add(btnNewCookbook, 1, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tblMain.Size = new Size(1247, 982);
            tblMain.TabIndex = 0;
            // 
            // gCookbookList
            // 
            gCookbookList.AllowUserToAddRows = false;
            gCookbookList.AllowUserToDeleteRows = false;
            gCookbookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbookList.Dock = DockStyle.Fill;
            gCookbookList.Location = new Point(65, 199);
            gCookbookList.Name = "gCookbookList";
            gCookbookList.ReadOnly = true;
            gCookbookList.RowHeadersWidth = 102;
            gCookbookList.Size = new Size(1116, 730);
            gCookbookList.StandardTab = true;
            gCookbookList.TabIndex = 0;
            // 
            // btnNewCookbook
            // 
            btnNewCookbook.AutoSize = true;
            btnNewCookbook.Location = new Point(65, 79);
            btnNewCookbook.Margin = new Padding(3, 30, 3, 30);
            btnNewCookbook.Name = "btnNewCookbook";
            btnNewCookbook.Size = new Size(305, 64);
            btnNewCookbook.TabIndex = 1;
            btnNewCookbook.Text = "&New Cookbook";
            btnNewCookbook.UseVisualStyleBackColor = true;
            // 
            // frmCookbookList
            // 
            AutoScaleDimensions = new SizeF(22F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1247, 982);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmCookbookList";
            Text = "Cookbook List";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private DataGridView gCookbookList;
        private Button btnNewCookbook;
    }
}
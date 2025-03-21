﻿namespace RecipeWinForms
{
    partial class frmSearch
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
            tblSearch = new TableLayoutPanel();
            lblRecipeName = new Label();
            txtRecipeName = new TextBox();
            btnSearch = new Button();
            btnNew = new Button();
            gRecipe = new DataGridView();
            tblMain.SuspendLayout();
            tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipe).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblSearch, 0, 0);
            tblMain.Controls.Add(gRecipe, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1755, 1196);
            tblMain.TabIndex = 0;
            // 
            // tblSearch
            // 
            tblSearch.AutoSize = true;
            tblSearch.ColumnCount = 4;
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tblSearch.Controls.Add(lblRecipeName, 0, 0);
            tblSearch.Controls.Add(txtRecipeName, 1, 0);
            tblSearch.Controls.Add(btnSearch, 2, 0);
            tblSearch.Controls.Add(btnNew, 3, 0);
            tblSearch.Location = new Point(3, 3);
            tblSearch.Name = "tblSearch";
            tblSearch.RowCount = 1;
            tblSearch.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblSearch.Size = new Size(604, 70);
            tblSearch.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.None;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 8);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(256, 54);
            lblRecipeName.TabIndex = 0;
            lblRecipeName.Text = "Recipe Name";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Location = new Point(265, 3);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(100, 61);
            txtRecipeName.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(371, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 64);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.AutoSize = true;
            btnNew.Location = new Point(527, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(74, 64);
            btnNew.TabIndex = 3;
            btnNew.Text = "&New";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // gRecipe
            // 
            gRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipe.Dock = DockStyle.Fill;
            gRecipe.Location = new Point(3, 79);
            gRecipe.Name = "gRecipe";
            gRecipe.RowHeadersWidth = 102;
            gRecipe.Size = new Size(1749, 1114);
            gRecipe.TabIndex = 1;
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(26F, 62F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1755, 1196);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5);
            Name = "frmSearch";
            Text = "Recipe Search";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblSearch.ResumeLayout(false);
            tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblSearch;
        private Label lblRecipeName;
        private TextBox txtRecipeName;
        private Button btnSearch;
        private DataGridView gRecipe;
        private Button btnNew;
    }
}
namespace RecipeWinForms
{
    partial class frmRecipeList
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
            gRecipeList = new DataGridView();
            btnNewRecipe = new Button();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipeList).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tblMain.Controls.Add(gRecipeList, 1, 2);
            tblMain.Controls.Add(btnNewRecipe, 1, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tblMain.Size = new Size(960, 731);
            tblMain.TabIndex = 0;
            // 
            // gRecipeList
            // 
            gRecipeList.AllowUserToOrderColumns = true;
            gRecipeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipeList.Dock = DockStyle.Fill;
            gRecipeList.Location = new Point(51, 148);
            gRecipeList.Name = "gRecipeList";
            gRecipeList.RowHeadersWidth = 102;
            gRecipeList.Size = new Size(858, 542);
            gRecipeList.StandardTab = true;
            gRecipeList.TabIndex = 0;
            // 
            // btnNewRecipe
            // 
            btnNewRecipe.AutoSize = true;
            btnNewRecipe.Location = new Point(51, 66);
            btnNewRecipe.Margin = new Padding(3, 30, 3, 30);
            btnNewRecipe.Name = "btnNewRecipe";
            btnNewRecipe.Size = new Size(200, 49);
            btnNewRecipe.TabIndex = 1;
            btnNewRecipe.Text = "&New Recipe";
            btnNewRecipe.UseVisualStyleBackColor = true;
            // 
            // frmRecipeList
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 731);
            Controls.Add(tblMain);
            Name = "frmRecipeList";
            Text = "Recipe List";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipeList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private DataGridView gRecipeList;
        private Button btnNewRecipe;
    }
}
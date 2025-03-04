namespace RecipeWinForms
{
    partial class frmCloneaRecipe
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lstRecipeName = new ComboBox();
            btnClone = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.71429F));
            tableLayoutPanel1.Controls.Add(lstRecipeName, 1, 1);
            tableLayoutPanel1.Controls.Add(btnClone, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.71428537F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 42.85714F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 2.85714269F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 42.85714F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.71428537F));
            tableLayoutPanel1.Size = new Size(1035, 593);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lstRecipeName
            // 
            lstRecipeName.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lstRecipeName.FormattingEnabled = true;
            lstRecipeName.Location = new Point(63, 235);
            lstRecipeName.Name = "lstRecipeName";
            lstRecipeName.Size = new Size(603, 62);
            lstRecipeName.TabIndex = 0;
            // 
            // btnClone
            // 
            btnClone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClone.AutoSize = true;
            btnClone.Location = new Point(478, 306);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(188, 64);
            btnClone.TabIndex = 1;
            btnClone.Text = "Clone";
            btnClone.UseVisualStyleBackColor = true;
            // 
            // frmCloneaRecipe
            // 
            AutoScaleDimensions = new SizeF(22F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 593);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmCloneaRecipe";
            Text = "Clone a Recipe";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox lstRecipeName;
        private Button btnClone;
    }
}
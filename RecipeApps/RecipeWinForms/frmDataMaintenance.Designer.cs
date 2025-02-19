namespace RecipeWinForms
{
    partial class frmDataMaintenance
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
            btnSave = new Button();
            gData = new DataGridView();
            pnlOptionButtons = new FlowLayoutPanel();
            optUsers = new RadioButton();
            optCuisines = new RadioButton();
            optIngredients = new RadioButton();
            optMeasurements = new RadioButton();
            optCourses = new RadioButton();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gData).BeginInit();
            pnlOptionButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.8273373F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.17266F));
            tblMain.Controls.Add(btnSave, 1, 1);
            tblMain.Controls.Add(gData, 1, 0);
            tblMain.Controls.Add(pnlOptionButtons, 0, 0);
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(4, 4, 10, 10);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 90.92344F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 9.076559F));
            tblMain.Size = new Size(1390, 1267);
            tblMain.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(1182, 1189);
            btnSave.Margin = new Padding(3, 3, 20, 20);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(188, 58);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // gData
            // 
            gData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gData.Dock = DockStyle.Fill;
            gData.Location = new Point(362, 3);
            gData.Name = "gData";
            gData.RowHeadersWidth = 102;
            gData.Size = new Size(1025, 1146);
            gData.TabIndex = 0;
            // 
            // pnlOptionButtons
            // 
            pnlOptionButtons.Controls.Add(optUsers);
            pnlOptionButtons.Controls.Add(optCuisines);
            pnlOptionButtons.Controls.Add(optIngredients);
            pnlOptionButtons.Controls.Add(optMeasurements);
            pnlOptionButtons.Controls.Add(optCourses);
            pnlOptionButtons.Dock = DockStyle.Fill;
            pnlOptionButtons.FlowDirection = FlowDirection.TopDown;
            pnlOptionButtons.Location = new Point(3, 3);
            pnlOptionButtons.Name = "pnlOptionButtons";
            pnlOptionButtons.Size = new Size(353, 1146);
            pnlOptionButtons.TabIndex = 2;
            // 
            // optUsers
            // 
            optUsers.AutoSize = true;
            optUsers.Checked = true;
            optUsers.Location = new Point(3, 3);
            optUsers.Name = "optUsers";
            optUsers.Size = new Size(156, 58);
            optUsers.TabIndex = 0;
            optUsers.TabStop = true;
            optUsers.Text = "&Users";
            optUsers.UseVisualStyleBackColor = true;
            // 
            // optCuisines
            // 
            optCuisines.AutoSize = true;
            optCuisines.Location = new Point(3, 67);
            optCuisines.Name = "optCuisines";
            optCuisines.Size = new Size(206, 58);
            optCuisines.TabIndex = 1;
            optCuisines.Text = "&Cuisines";
            optCuisines.UseVisualStyleBackColor = true;
            // 
            // optIngredients
            // 
            optIngredients.AutoSize = true;
            optIngredients.Location = new Point(3, 131);
            optIngredients.Name = "optIngredients";
            optIngredients.Size = new Size(262, 58);
            optIngredients.TabIndex = 2;
            optIngredients.Text = "&Ingredients";
            optIngredients.UseVisualStyleBackColor = true;
            // 
            // optMeasurements
            // 
            optMeasurements.AutoSize = true;
            optMeasurements.Location = new Point(3, 195);
            optMeasurements.Name = "optMeasurements";
            optMeasurements.Size = new Size(321, 58);
            optMeasurements.TabIndex = 3;
            optMeasurements.Text = "&Measurements";
            optMeasurements.UseVisualStyleBackColor = true;
            // 
            // optCourses
            // 
            optCourses.AutoSize = true;
            optCourses.Location = new Point(3, 259);
            optCourses.Name = "optCourses";
            optCourses.Size = new Size(200, 58);
            optCourses.TabIndex = 4;
            optCourses.Text = "C&ourses";
            optCourses.UseVisualStyleBackColor = true;
            // 
            // frmDataMaintenance
            // 
            AutoScaleDimensions = new SizeF(22F, 54F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 1267);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "frmDataMaintenance";
            Text = "Data Maintenance";
            tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gData).EndInit();
            pnlOptionButtons.ResumeLayout(false);
            pnlOptionButtons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnSave;
        private DataGridView gData;
        private FlowLayoutPanel pnlOptionButtons;
        private RadioButton optUsers;
        private RadioButton optCuisines;
        private RadioButton optIngredients;
        private RadioButton optMeasurements;
        private RadioButton optCourses;
    }
}
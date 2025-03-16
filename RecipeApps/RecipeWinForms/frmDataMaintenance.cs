namespace RecipeWinForms
{
    public partial class frmDataMaintenance : Form
    {
        private enum TableTypeEnum { User, Cuisine, Ingredient, Measurement, Course}
        DataTable dtlist = new();
        TableTypeEnum currenttabletype = TableTypeEnum.User;
        string deletecolname = "deletecol";
        
        public frmDataMaintenance()
        {
            InitializeComponent();
            SetupRadioButtons();
            btnSave.Click += BtnSave_Click;
            this.FormClosing += FrmDataMaintenance_FormClosing;
            gData.CellContentClick += GData_CellContentClick;
            BindData(currenttabletype);
            gData.DataError += GData_DataError;
        }

        private void BindData(TableTypeEnum tabletype)
        {
            currenttabletype = tabletype;
            dtlist = DataMaintenance.GetDataList(currenttabletype.ToString());
            gData.Columns.Clear();            
            gData.DataSource = dtlist;
            if (gData.Columns.Contains("UserName") && gData.Columns.Contains("ListOrder"))
            {
                gData.Columns["UserName"].Visible = false;
                gData.Columns["ListOrder"].Visible = false;
            }
            WindowsFormsUtility.AddDeleteButtonToGrid(gData, deletecolname);
            WindowsFormsUtility.FormatGridForEdit(gData, tabletype.ToString());
        }

        private bool Save()
        {
            bool b = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                DataMaintenance.SaveDataList(dtlist, currenttabletype.ToString());
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally {Cursor = Cursors.Default; }
            return b;
        }

        private void Delete(int rowindex)
        {
            string tabledeletemessage = $"Are you sure you want to delete this {currenttabletype.ToString()}?";
            if(currenttabletype == TableTypeEnum.User)
            {
                tabledeletemessage = "Are you sure you want to delete this user, this will cause you to delete all related recipes, meals, and cookbooks. Do you wish to continue?";
            }
            int id = WindowsFormsUtility.GetIdFromGrid(gData, rowindex, currenttabletype.ToString() + "Id");
            if (id < 1) { return; }
            if (id != 0)
            {
                var response = MessageBox.Show(tabledeletemessage, Application.ProductName, MessageBoxButtons.YesNo);
                if (response == DialogResult.No)
                {
                    return;
                }
                Application.UseWaitCursor = true;
                try
                {
                    DataMaintenance.DeleteRow(currenttabletype.ToString(), id);
                    BindData(currenttabletype);                                            
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
                finally
                {
                    Application.UseWaitCursor = false;
                }
            }
            else if (id == 0 && rowindex < gData.Rows.Count)
            {
                gData.Rows.RemoveAt(rowindex);
            }

        }

        private void SetupRadioButtons()
        {
            foreach (Control c in pnlOptionButtons.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click;
                }
            }
            optUsers.Tag = TableTypeEnum.User;
            optCuisines.Tag = TableTypeEnum.Cuisine;
            optIngredients.Tag = TableTypeEnum.Ingredient;
            optMeasurements.Tag = TableTypeEnum.Measurement;
            optCourses.Tag = TableTypeEnum.Course;
        }

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Control && ((Control)sender).Tag is TableTypeEnum)
            {
                BindData((TableTypeEnum)((Control)sender).Tag);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

        private void FrmDataMaintenance_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (SQLUtility.TableHasChanges(dtlist))
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing the form?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if (b == false)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        this.Activate();
                        break;
                }

            }
        }

        //sk - should this be entered in the architecture?
        private void DataErrorMessage()
        {
            MessageBox.Show("Course sequence column can only contain numeric values.", "Recipe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void GData_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gData.Columns[e.ColumnIndex].Name == deletecolname)
            {
                Delete(e.RowIndex);
            }
        }

        private void GData_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            DataErrorMessage();
        }

    }
}

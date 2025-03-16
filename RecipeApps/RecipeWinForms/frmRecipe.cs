using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe = new();
        DataTable dtrecipeingredient = new();
        DataTable dtrecipestep = new();
        BindingSource bindsource = new();
        string deletecolname = "deletecol";
        int recipeid = 0;
        bool bFormBounded = false;


        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            txtRecipeName.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.FormClosing += FrmRecipe_FormClosing;
            btnSaveIngredient.Click += BtnSaveIngredient_Click;
            gIngredients.CellContentClick += GIngredients_CellContentClick;
            btnSaveSteps.Click += BtnSaveSteps_Click;
            gSteps.CellContentClick += GSteps_CellContentClick;
            btnChangeStatus.Click += BtnChangeStatus_Click;
            this.Shown += FrmRecipe_Shown;
            this.Activated += FrmRecipe_Activated;
            this.gIngredients.DataError += GIngredients_DataError;
            this.gSteps.DataError += GSteps_DataError;
            txtCalories.KeyPress += TxtCalories_KeyPress;
        }

        public void LoadForm(int recipeidval)
        {
            if (!bFormBounded || recipeidval > 0)
            {
                recipeid = recipeidval;
                this.Tag = recipeid;
                dtrecipe = Recipe.Load(recipeid);
                bindsource.DataSource = dtrecipe;
                if (recipeid == 0)
                {
                    dtrecipe.Rows.Add();
                }
                if (!bFormBounded)
                {

                    DataTable dtusers = Recipe.GetUsersList();
                    DataTable dtcuisine = Recipe.GetCuisineList();

                    WindowsFormsUtility.SetListBinding(lstUserName, dtusers, dtrecipe, "User");
                    WindowsFormsUtility.SetListBinding(lstTitle, dtcuisine, dtrecipe, "Cuisine");

                    WindowsFormsUtility.SetControlBinding(txtRecipeName, bindsource);

                    WindowsFormsUtility.SetControlBinding(lblDateDraft, bindsource);
                    WindowsFormsUtility.SetControlBinding(lblDatePublished, bindsource);
                    WindowsFormsUtility.SetControlBinding(lblDateArchived, bindsource);
                    WindowsFormsUtility.SetControlBinding(txtCalories, bindsource);
                    WindowsFormsUtility.SetControlBinding(lblRecipeStatus, bindsource);

                    bFormBounded = true;

                    this.Text = GetRecipeDesc();
                    SetButtonsEnablesBasedOnNewRecord();
                }
            }
        }

        private void FrmRecipe_Activated(object? sender, EventArgs e)
        {
            LoadForm(recipeid);
        }
        private void FrmRecipe_Shown(object? sender, EventArgs e)
        {
            LoadRecipeIngredient();
            LoadRecipeSteps();
        }
        private void LoadRecipeIngredient()
        {
            dtrecipeingredient = RecipeIngredient.LoadByRecipeId(recipeid);
            gIngredients.Columns.Clear();
            gIngredients.DataSource = dtrecipeingredient;
            WindowsFormsUtility.AddDeleteButtonToGrid(gIngredients, deletecolname);
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, DataMaintenance.GetDataList("Ingredient"), "Ingredient", "IngredientName");
            WindowsFormsUtility.AddComboBoxToGrid(gIngredients, DataMaintenance.GetDataList("Measurement", true), "Measurement", "MeasurementType");
            WindowsFormsUtility.FormatGridForEdit(gIngredients, "RecipeIngredient");
        }

        private void LoadRecipeSteps()
        {
            dtrecipestep = RecipeStep.LoadByRecipeId(recipeid);
            gSteps.Columns.Clear();
            gSteps.DataSource = dtrecipestep;
            WindowsFormsUtility.FormatGridForEdit(gSteps, "RecipeDirection");
            WindowsFormsUtility.AddDeleteButtonToGrid(gSteps, deletecolname);
        }

        private bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;

            try
            {
                Recipe.Save(dtrecipe);
                b = true;
                bindsource.ResetBindings(false);
                recipeid = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");
                this.Tag = recipeid;
                SetButtonsEnablesBasedOnNewRecord();
                this.Text = GetRecipeDesc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Recipe");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;

        }


        private void Delete()
        {
            var response = MessageBox.Show("Are you sure you want to delete this Recipe?", Application.ProductName, MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Recipe.Delete(dtrecipe);
                this.Close();
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

        private void BtnChangeStatus_Click(object? sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (this.MdiParent != null && this.MdiParent is frmMain)
                {
                    frmChangeStatus f = new();
                    f.MdiParent = this.MdiParent;
                    f.LoadData(recipeid);
                    f.Show();
                    f.ButtonEnabled();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void SaveRecipeIngredient()
        {
            try
            {
                RecipeIngredient.SaveTable(dtrecipeingredient, recipeid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void DeleteRecipeIngredient(int rowIndex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gIngredients, rowIndex, "RecipeIngredientId");
            if (id < 1) { return; }

            var response = MessageBox.Show("Are you sure you want to delete this Recipe Ingredient?", Application.ProductName, MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }

            if (id > 0)
            {
                try
                {
                    RecipeIngredient.Delete(id);
                    LoadRecipeIngredient();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, Application.ProductName); }
            }
            else if (id < gIngredients.Rows.Count) { gIngredients.Rows.RemoveAt(rowIndex); }
        }

        private void SaveRecipeStep()
        {
            try
            {
                RecipeStep.SaveTable(dtrecipestep, recipeid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }
        private void DeleteRecipeStep(int rowIndex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gSteps, rowIndex, "DirectionId");
            if (id < 1) { return; }

            var response = MessageBox.Show("Are you sure you want to delete this Recipe Step?", Application.ProductName, MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }

            if (id > 0)
            {
                try
                {
                    RecipeStep.Delete(id);
                    LoadRecipeSteps();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, Application.ProductName); }
            }
            else if (id < gSteps.Rows.Count) { gSteps.Rows.RemoveAt(rowIndex); }
        }

        private void SetButtonsEnablesBasedOnNewRecord()
        {
            bool b = recipeid == 0 ? false : true;
            btnDelete.Enabled = b;
            btnChangeStatus.Enabled = b;
            btnSaveIngredient.Enabled = b;
            btnSaveSteps.Enabled = b;
        }
        private string GetRecipeDesc()
        {
            string value = "New Recipe";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtrecipe, "RecipeId");
            if (pkvalue > 0)
            {
                value = SQLUtility.GetValueFromFirstRowAsString(dtrecipe, "RecipeName");
            }
            return value;
        }

        private void FrmRecipe_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindsource.EndEdit();
            if (SQLUtility.TableHasChanges(dtrecipe))
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

        private void TxtCalories_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Allow only numeric input (including backspace to delete)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Block the non-numeric character
            }
        }

        private void DataErrorMessage()
        {
            MessageBox.Show("Please enter only numeric values.", "Recipe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      
        private void GSteps_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            DataErrorMessage();
        }

        private void GIngredients_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            DataErrorMessage();
        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
        private void BtnSaveIngredient_Click(object? sender, EventArgs e)
        {
            SaveRecipeIngredient();
        }

        private void BtnSaveSteps_Click(object? sender, EventArgs e)
        {
            SaveRecipeStep();
        }

        private void GIngredients_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteRecipeIngredient(e.RowIndex);
        }

        private void GSteps_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteRecipeStep(e.RowIndex);
        }

    }
}

namespace RecipeWinForms
{
    public partial class frmCookbook : Form
    {
        DataTable dtcookbook = new();
        DataTable dtcookbookrecipe = new();
        BindingSource bindsource = new();
        string deletecolname = "deletecol";
        int cookbookid = 0;
        public frmCookbook()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            txtCookbookName.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            this.FormClosing += FrmCookbook_FormClosing;
            btnSaveCookbookRecipes.Click += BtnSaveCookbookRecipes_Click;
            gCookbookRecipes.CellContentClick += GCookbookRecipes_CellContentClick;
            this.gCookbookRecipes.DataError += GCookbookRecipes_DataError;
        }

        private void GCookbookRecipes_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Can only insert numeric values", "Cookbook");
        }

        public new void Load(int cookbookidval)
        {
            cookbookid = cookbookidval;
            this.Tag = cookbookid;
            dtcookbook = Cookbook.Load(cookbookid);
            bindsource.DataSource = dtcookbook;
            if (cookbookid == 0)
            {
                dtcookbook.Rows.Add();
                dtcookbook.Rows[0].SetField("Active", false);
            }
            DataTable dtusers = Cookbook.GetUsersList();
            WindowsFormsUtility.SetControlBinding(txtCookbookName, bindsource);
            WindowsFormsUtility.SetListBinding(lstUserName, dtusers, dtcookbook, "User");
            WindowsFormsUtility.SetControlBinding(txtPrice, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateCreated, bindsource);
           // WindowsFormsUtility.SetCheckedBinding(cbActive,bindsource);
            cbActive.DataBindings.Add("Checked", dtcookbook, "Active", false, DataSourceUpdateMode.OnPropertyChanged);
            this.Text = GetCookbookDesc();            
            LoadCookbookRecipe();
            SetButtonsEnablesBasedOnNewRecord();
        }
        private void SetButtonsEnablesBasedOnNewRecord()
        {
            bool b = cookbookid == 0 ? false : true;
            btnDelete.Enabled = b;
            btnSaveCookbookRecipes.Enabled = b;
        }

        private string GetCookbookDesc()
        {
            string value = "New Cookbook";
            int pkvalue = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "CookbookId");
            if (pkvalue > 0)
            {
                value = SQLUtility.GetValueFromFirstRowAsString(dtcookbook, "CookbookName");// + SQLUtility.GetValueFromFirstRowAsString(dtcookbook, "CookbookName");
            }
            return value;
        }
        public void LoadCookbookRecipe()
        {
            dtcookbookrecipe = CookbookRecipe.LoadByCookbookId(cookbookid);
            gCookbookRecipes.Columns.Clear();
            gCookbookRecipes.DataSource = dtcookbookrecipe;
            WindowsFormsUtility.AddDeleteButtonToGrid(gCookbookRecipes, deletecolname);
            WindowsFormsUtility.AddComboBoxToGrid(gCookbookRecipes, DataMaintenance.GetDataList("Recipe"), "Recipe", "RecipeName");
            WindowsFormsUtility.FormatGridForEdit(gCookbookRecipes, "CookbookRecipe");
        }
        private bool Save()
      {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                Cookbook.Save(dtcookbook);
                b = true;
                bindsource.ResetBindings(false);
                cookbookid = SQLUtility.GetValueFromFirstRowAsInt(dtcookbook, "cookbookId");
                this.Tag = cookbookid;
                SetButtonsEnablesBasedOnNewRecord();
                this.Text = GetCookbookDesc();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cookbook");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }
        private void Delete()
        {
            var response = MessageBox.Show("Are you sure you want to delete this Cookbook?", Application.ProductName, MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Cookbook.Delete(dtcookbook);
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

        private void SaveCookbookRecipes()
        {
            try
            {
                CookbookRecipe.SaveTable(dtcookbookrecipe, cookbookid);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            
        }
        private void DeleteCookbookRecipes(int rowIndex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gCookbookRecipes, rowIndex, "CookbookRecipeId");
            if (id < 1) {return; }

            var response = MessageBox.Show("Are you sure you want to delete this Recipe from this Cookbook?", Application.ProductName, MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            
            if (id > 0)
            {
                try
                {
                    CookbookRecipe.Delete(id);
                    LoadCookbookRecipe();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message, Application.ProductName); }
                finally { Application.UseWaitCursor = false; }
            }
            else if (id < gCookbookRecipes.Rows.Count)
            {
                gCookbookRecipes.Rows.RemoveAt(rowIndex);
            }
        }

        private void FrmCookbook_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindsource.EndEdit();
            if (SQLUtility.TableHasChanges(dtcookbook))
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

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }      

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }
        private void BtnSaveCookbookRecipes_Click(object? sender, EventArgs e)
        {
            SaveCookbookRecipes();
        }
        private void GCookbookRecipes_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            DeleteCookbookRecipes(e.RowIndex);
        }
       
    }
}

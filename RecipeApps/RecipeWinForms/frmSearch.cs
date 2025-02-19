namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            gRecipe.CellDoubleClick += GRecipe_CellDoubleClick;
            btnNew.Click += BtnNew_Click;
            txtRecipeName.KeyDown += TxtRecipeName_KeyDown;
            gRecipe.KeyDown += GRecipe_KeyDown;
            //WindowsFormsUtility.FormatGridForSearchResults(gRecipe, "Recipe");
        }


        // private void SearchForRecipe(string recipename)
        // {
        //   DataTable dt = Recipe.SearchRecipes(recipename);
        //gRecipe.DataSource = dt;
        //     gRecipe.Columns["RecipeId"].Visible = false;
        // }

        private void SearchForRecipe(string recipename)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                //DataTable dt = Recipe.SearchRecipe(recipename);
                //gRecipe.DataSource = dt;
                WindowsFormsUtility.FormatGridForSearchResults(gRecipe, "Recipe");
                if (gRecipe.Rows.Count > 0)
                {
                    gRecipe.Focus();
                    gRecipe.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gRecipe, rowindex, "RecipeId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), id);
            }
        }

        //private void FormatGrid()
        //{
        //    gRecipe.AllowUserToAddRows = false;
        //    gRecipe.ReadOnly = true;
        //    gRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    gRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //}

        //private void DoSearch()
        //{
        //    int userid = 0;
        //    int cuisineid = 0;
        //    int calories = 0;
        //    string recipestatus = "";


        //    if (lstUser.SelectedValue != null && lstUser.SelectedValue is int)
        //    {
        //        userid = (int)lstUser.SelectedValue;
        //    }
        //    int.TryParse(txtCalories.Text, out calories);
        //    int.TryParse(txtRecipeStatus.Text, out recipestatus);
        //    SearchForRecipe(userid,cuisineid,txtRecipeName.Text, txtRecipeStatus.Text, calories);
        //}
        private void GRecipe_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeForm(e.RowIndex);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtRecipeName.Text);
        }
        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);
        }

        private void GRecipe_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SearchForRecipe(txtRecipeName.Text); }
        }

        private void TxtRecipeName_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gRecipe.SelectedRows.Count > 0)
            {
                ShowRecipeForm(gRecipe.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }
    }
}

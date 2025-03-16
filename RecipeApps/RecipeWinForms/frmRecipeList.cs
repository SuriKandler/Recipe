namespace RecipeWinForms
{
    public partial class frmRecipeList : Form
    {
        public frmRecipeList()
        {
            InitializeComponent();            
            SetUpListGrid();
            gRecipeList.CellDoubleClick += GRecipeList_CellDoubleClick;
            gRecipeList.KeyDown += GRecipeList_KeyDown;
            btnNewRecipe.Click += BtnNewRecipe_Click;
            this.Activated += FrmRecipeList_Activated;
        }

        private void FrmRecipeList_Activated(object? sender, EventArgs e)
        {
            SetUpListGrid();
        }

        //private void SetUpListGrid()
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;
        //        gRecipeList.DataSource = DataMaintenance.GetDataListNoParam("RecipeList");
        //        WindowsFormsUtility.FormatGridForSearchResults(gRecipeList, "Recipe");
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        this.Cursor = Cursors.Default;
        //    }
        //}
        private void SetUpListGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                gRecipeList.DataSource = DataMaintenance.GetDataList("Recipe", false);
                WindowsFormsUtility.FormatGridForSearchResults(gRecipeList, "Recipe");
                if (gRecipeList.Columns.Contains("DateDraft") && gRecipeList.Columns.Contains("DatePublished") && gRecipeList.Columns.Contains("DateArchived") && gRecipeList.Columns.Contains("ListOrder"))
                {
                    gRecipeList.Columns["DateDraft"].Visible = false;
                    gRecipeList.Columns["DatePublished"].Visible = false;
                    gRecipeList.Columns["DateArchived"].Visible = false;
                    gRecipeList.Columns["ListOrder"].Visible = false;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ShowRecipeForm(int rowindex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int id = 0;
                if (rowindex > -1)
                {
                    id = WindowsFormsUtility.GetIdFromGrid(gRecipeList, rowindex, "RecipeId");
                }
                if (this.MdiParent != null && this.MdiParent is frmMain)
                {
                    ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), id);
                }
            }
            catch 
            { 
                throw; 
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GRecipeList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            { return; }
            ShowRecipeForm(e.RowIndex);
        }

        private void GRecipeList_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gRecipeList.SelectedRows.Count > 0)
            {
                ShowRecipeForm(gRecipeList.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }
        private void BtnNewRecipe_Click(object? sender, EventArgs e)
        {
            ShowRecipeForm(-1);
        }
    }
}

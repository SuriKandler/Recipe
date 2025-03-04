namespace RecipeWinForms
{
    public partial class frmCookbookList : Form
    {
        public frmCookbookList()
        {
            InitializeComponent();
            SetUpListGrid();
            btnNewCookbook.Click += BtnNewCookbook_Click;
            gCookbookList.CellDoubleClick += GCookbookList_CellDoubleClick;
            gCookbookList.KeyDown += GCookbookList_KeyDown;
            this.Activated += FrmCookbookList_Activated;
        }

        private void FrmCookbookList_Activated(object? sender, EventArgs e)
        {
            SetUpListGrid();
        }

        private void SetUpListGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                gCookbookList.DataSource = DataMaintenance.GetDataList("Cookbook", false);
                WindowsFormsUtility.FormatGridForSearchResults(gCookbookList, "Cookbook");

                if (gCookbookList.Columns.Contains("DateCreated") && gCookbookList.Columns.Contains("Active"))
                {
                    gCookbookList.Columns["DateCreated"].Visible = false;
                    gCookbookList.Columns["Active"].Visible = false;
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
        
        private void ShowCookbookForm(int rowindex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int id = 0;
                if (rowindex > -1)
                {
                    id = WindowsFormsUtility.GetIdFromGrid(gCookbookList, rowindex, "CookbookId");
                }
                if (this.MdiParent != null && this.MdiParent is frmMain)
                {
                    ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook), id);
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
        private void GCookbookList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            { return; }
            ShowCookbookForm(e.RowIndex);
        }

        private void GCookbookList_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gCookbookList.SelectedRows.Count > 0)
            {
                ShowCookbookForm(gCookbookList.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }

        private void BtnNewCookbook_Click(object? sender, EventArgs e)
        {
            ShowCookbookForm(-1);
        }
    }
}

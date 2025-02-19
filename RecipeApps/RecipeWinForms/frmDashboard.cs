namespace RecipeWinForms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            this.Activated += FrmDashboard_Activated;
            btnRecipeList.Click += BtnRecipeList_Click;
            btnMealList.Click += BtnMealList_Click;
            btnCookbookList.Click += BtnCookbookList_Click;
        }

        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {
            SetUpListGrid(gTotalList);
        }

        private void SetUpListGrid(DataGridView grid)
        {
            Application.UseWaitCursor = true;
            try
            {
                DataTable dt = DataMaintenance.GetDataListNoParam("DashboardGet");
                gTotalList.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dashboard");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void ShowList(Type frmtype)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(frmtype);
            }
        }

        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
            ShowList(typeof(frmCookbookList));
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
            ShowList(typeof(frmMealList));
        }

        private void BtnRecipeList_Click(object? sender, EventArgs e)
        {
            ShowList(typeof(frmRecipeList));
        }

      
    }

}
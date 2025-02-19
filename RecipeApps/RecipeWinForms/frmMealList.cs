namespace RecipeWinForms
{
    public partial class frmMealList : Form
    {
        public frmMealList()
        {
            InitializeComponent();
            SetUpListGrid();
        }

        private void SetUpListGrid()
        {
            gMealList.DataSource = DataMaintenance.GetDataList("Meal", false);
            WindowsFormsUtility.FormatGridForSearchResults(gMealList, "Meal");
        }
    }
}

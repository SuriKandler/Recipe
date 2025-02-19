namespace RecipeWinForms
{
    public partial class frmCloneaRecipe : Form
    {
        public frmCloneaRecipe()
        {
            InitializeComponent();
            BindData();
            btnClone.Click += BtnClone_Click;
        }

        private void BindData()
        {
            WindowsFormsUtility.SetListBinding(lstRecipeName, DataMaintenance.GetDataList("Recipe"), null, "Recipe");
        }

        private void CloneaRecipe()
        {
            int baserecipeid = WindowsFormsUtility.GetIdFromComboBox(lstRecipeName);
            if (baserecipeid != 0)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    var recipeid = Recipe.CloneaRecipe(baserecipeid);

                    if (this.MdiParent != null && this.MdiParent is frmMain)
                    {
                        ((frmMain)this.MdiParent).OpenForm(typeof(frmRecipe), recipeid);

                        this.Close();
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
           

        }
        private void BtnClone_Click(object? sender, EventArgs e)
        {
            CloneaRecipe();
        }
    }
}

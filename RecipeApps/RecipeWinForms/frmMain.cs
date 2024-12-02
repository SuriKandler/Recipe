namespace RecipeWinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            mnuRecipesList.Click += MnuRecipesList_Click;
            mnuNewRecipe.Click += MnuNewRecipe_Click;
            mnuCloneARecipe.Click += MnuCloneARecipe_Click;
        }

        private void MnuCloneARecipe_Click(object? sender, EventArgs e)
        {
            
        }

        private void MnuNewRecipe_Click(object? sender, EventArgs e)
        {
            frmRecipe f = new frmRecipe();
            f.MdiParent = this;
            f.Show();
        }

        private void MnuRecipesList_Click(object? sender, EventArgs e)
        {
            
        }
    }
}

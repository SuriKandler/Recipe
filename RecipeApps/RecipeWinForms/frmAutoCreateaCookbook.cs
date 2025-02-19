namespace RecipeWinForms
{
    public partial class frmAutoCreateaCookbook : Form
    {
        public frmAutoCreateaCookbook()
        {
            InitializeComponent();
            BindData();
            btnCreateCookbook.Click += BtnCreateCookbook_Click;
        }

        private void BindData()
        {
            WindowsFormsUtility.SetListBinding(lstUserName, DataMaintenance.GetDataList("User",true), null, "User");
        }
        private void CreateCookbook()
        {
            int userid = WindowsFormsUtility.GetIdFromComboBox(lstUserName);
            if (userid != 0)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    var cookbookId = Cookbook.AutoCreateaCookbook(userid);

                    if (this.MdiParent != null && this.MdiParent is frmMain)
                    {
                        ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbook), cookbookId);
                        this.Close();
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message, Application.ProductName); }
            finally { Cursor = Cursors.Default; }
            }
                   }
        private void BtnCreateCookbook_Click(object? sender, EventArgs e)
        {
            CreateCookbook();
        }

       
    }
}

namespace RecipeWinForms

{
    public partial class frmChangeStatus : Form
    {
        DataTable dtchangestatus = new();
        BindingSource bindsource = new();
        int recipeid = 0;
        private enum Status { Draft, Published, Archived }

        public frmChangeStatus()
        {
            InitializeComponent();
            btnDraft.Click += BtnAll_Click;
            btnPublish.Click += BtnAll_Click;
            btnArchive.Click += BtnAll_Click;            
        }

        public void LoadData(int recipeidval)
        {
            recipeid = recipeidval;
            this.Tag = recipeid;
            dtchangestatus = Recipe.ChangeStatus(recipeid);
            bindsource.DataSource = dtchangestatus;
            WindowsFormsUtility.SetControlBinding(lblRecipeName, bindsource);
            WindowsFormsUtility.SetControlBinding(lblRecipeStatus, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateDraft, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, bindsource);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, bindsource);                        
        }        
        public void ButtonEnabled()
        { 
            if (lblRecipeStatus.Text == "Draft")
            {
                btnDraft.Enabled = false;
                btnArchive.Enabled = true;
                btnPublish.Enabled = true;
            }
            else if (lblRecipeStatus.Text == "Published")
            {
                btnPublish.Enabled = false;
                btnDraft.Enabled = true;
                btnArchive.Enabled = true;
            }
            else if (lblRecipeStatus.Text == "Archived")
            {
                btnArchive.Enabled = false;
                btnPublish.Enabled = true;
                btnDraft.Enabled = true;
            }            
        }     
        private void BtnAll_Click(object? sender, EventArgs e)
        {
            Button clickedbutton = (Button)sender;
            if (clickedbutton != null)
            {
                ChangeRecipesStatus(clickedbutton.Text);
                ButtonEnabled();
            }
        }

         private void ChangeRecipesStatus(String clickedbutton)
        {       

            Cursor = Cursors.WaitCursor;
            try
            {
                var res = MessageBox.Show($"Are you sure you want to change this recipe to {clickedbutton}?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        Recipe.UpdateStatus(clickedbutton, DateTime.Now, recipeid);
                        dtchangestatus = Recipe.ChangeStatus(recipeid);
                        bindsource.DataSource = dtchangestatus;

                        break;
                    case DialogResult.Cancel:

                        break;
                    case DialogResult.No:

                        break;
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
}

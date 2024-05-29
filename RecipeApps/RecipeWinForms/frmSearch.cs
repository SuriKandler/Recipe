using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPUFramework;
using CPUWindowsFormFramework;


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
            WindowsFormsUtility.FormatGridForSearchResults(gRecipe);
        }

     

        private void SearchForRecipe(string RecipeName)
        {
            string sql = "select RecipeId, RecipeName, DateDraft, DatePublished, DateArchived, Calories, RecipeStatus from Recipe r where r.RecipeName like '%" + RecipeName + "%'";
            Debug.Print(sql);
            DataTable dt = SQLUtility.GetDataTable(sql);
            gRecipe.DataSource = dt;
            gRecipe.Columns["RecipeId"].Visible = false;
        }

        private void ShowRecipeForm(int rowindex)
        {
            int id = 0;
            if(rowindex > -1)
            {
                id = (int)gRecipe.Rows[rowindex].Cells["RecipeId"].Value;
            }
            frmRecipe frm = new frmRecipe();
            frm.ShowForm(id);
        }

        //private void FormatGrid()
        //{
        //    gRecipe.AllowUserToAddRows = false;
        //    gRecipe.ReadOnly = true;
        //    gRecipe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    gRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

    }
}

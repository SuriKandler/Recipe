using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }
        public void ShowForm(int recipeid)
        {
            string sql = "select r.* from Recipe r where r.RecipeId = " + recipeid.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            lblRecipe.DataBindings.Add("Text", dt, "RecipeName");
            txtDateDraft.DataBindings.Add("Text", dt, "DateDraft");
            txtDatePublished.DataBindings.Add("Text", dt, "DatePublished");
            txtDateArchived.DataBindings.Add("Text", dt, "DateArchived");
            lblCaloriesAmount.DataBindings.Add("Text", dt, "Calories");
            lblStatus.DataBindings.Add("Text", dt, "RecipeStatus");
            
            this.Show();
        }
    }
}

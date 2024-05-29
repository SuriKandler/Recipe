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
    public partial class frmRecipe : Form
    {
        DataTable dtrecipe;
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            txtRecipeName.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }

        public void ShowForm(int recipeid)
        {
            string sql = "select r.* from Recipe r where r.RecipeId = " + recipeid.ToString();
            dtrecipe = SQLUtility.GetDataTable(sql);
            if (recipeid == 0)
            {
                dtrecipe.Rows.Add();
            }
            DataTable dtusers = SQLUtility.GetDataTable("select UserId, UserName from Users");
            DataTable dtcuisine = SQLUtility.GetDataTable("select CuisineId, Title from Cuisine");
            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtrecipe);
            WindowsFormsUtility.SetListBinding(lstUserName, dtusers, dtrecipe, "User");
            WindowsFormsUtility.SetListBinding(lstTitle, dtcuisine, dtrecipe, "Cuisine");
            WindowsFormsUtility.SetControlBinding(dtpDateDraft, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtrecipe);
            WindowsFormsUtility.SetControlBinding(txtRecipeStatus, dtrecipe);
            this.Show();
        }

        private void Save()
        {
            DataRow r = dtrecipe.Rows[0];
            int id = (int)r["RecipeId"];
            string sql = "";

            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
                    $"UserId = '{r["UserId"]}',",
                    $"CuisineId = '{r["CuisineId"]}',",
                    $"RecipeName = '{r["RecipeName"]}',",
                    $"DateDraft = '{r["DateDraft"]}',",
                    $"Calories = '{r["Calories"]}'",                    
                $"where RecipeId = '{r["RecipeId"]}'");
            }
            else
            {
                sql = "insert recipe(UserId, CuisineId, RecipeName, DateDraft, Calories)"; 
                sql += $"select '{r["UserId"]}', '{r["CuisineId"]}', '{r["RecipeName"]}','{r["DateDraft"]}', '{r["Calories"]}'"; 
            }
            Debug.Print("---------");

            SQLUtility.ExecuteSQL(sql);
        }

        private void Delete()
        {
            int id = (int)dtrecipe.Rows[0]["recipeId"];
            string sql = "delete recipe where recipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
            this.Close();
        }
        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

      
    }
}
//, RecipeStatus
//    $"RecipeStatus = '{r["RecipeStatus"]}'",
//, { r["RecipeStatus"]}
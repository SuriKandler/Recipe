using System.Data;
using System.Diagnostics;


namespace RecipeSystem
{
    public class Recipe
    {
        public static DataTable SearchRecipes(string recipename)
        {
            string sql = "select RecipeId, RecipeName, DateDraft, DatePublished, DateArchived, Calories, RecipeStatus from Recipe r where r.RecipeName like '%" + recipename + "%'";
            DataTable dt = SQLUtility.GetDataTable(sql);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            string sql = "select r.* from Recipe r where r.RecipeId = " + recipeid.ToString();
            return SQLUtility.GetDataTable(sql);
        }

        public static DataTable GetUsersList()
        {
            return SQLUtility.GetDataTable("select UserId, UserName from Users");
            
        }

        public static DataTable GetCuisineList()
        {
            return SQLUtility.GetDataTable("select CuisineId, Title from Cuisine");
        }

        public static void Save(DataTable dtrecipe)
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
                    //$"DateDraft = '{r["GetDate()"]}',",
                    $"Calories = '{r["Calories"]}'",
                $"where RecipeId = '{r["RecipeId"]}'");
            }
            else
            {
                sql = "insert recipe(UserId, CuisineId, RecipeName, DateDraft, Calories)";
                sql += $"select '{r["UserId"]}', '{r["CuisineId"]}', '{r["RecipeName"]}', GetDate(), '{r["Calories"]}'";
            }
            Debug.Print("---------");

            SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["recipeId"];
            string sql = "delete recipe where recipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
                    }
    }
}

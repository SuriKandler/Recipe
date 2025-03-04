using System.Data;
using System.Data.SqlClient;


namespace RecipeSystem
{
    public class Recipe
    {
              
        public static DataTable Load(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeGet");
            cmd.Parameters["@RecipeId"].Value = recipeid;
            cmd.Parameters["@IncludeBlank"].Value = 0;
            return SQLUtility.GetDataTable(cmd);
        }
        

        public static DataTable GetDataList(string tablename, bool includeblank = false)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand(tablename + "Get");
            cmd.Parameters["@All"].Value = 1;
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }
        
        public static DataTable GetUsersList(bool includeblank = false)
        {
            DataTable dt = GetDataList("User");
            return dt;
        }

        public static DataTable GetCuisineList(bool includeblank = false)
        {
            DataTable dt = GetDataList("Cuisine");
            return dt;
        }

        public static int CloneaRecipe(int baserecipeid)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand("CloneaRecipe");
            SQLUtility.SetParamValue(cmd, "@BaseRecipeId", baserecipeid);
            SQLUtility.ExecuteSQL(cmd);    
            var recipeid = (int)cmd.Parameters["@RecipeId"].Value;
            return recipeid;
        }

        public static DataTable ChangeStatus(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("ChangeStatusGet");
            cmd.Parameters["@RecipeId"].Value = recipeid;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable UpdateStatus(string Status, DateTime dt, int recipeid)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand("ChangeStatusUpdate");
            SQLUtility.SetParamValue(cmd, "@Date", dt);
            SQLUtility.SetParamValue(cmd, "@Status", Status );
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeid);
            return SQLUtility.GetDataTable(cmd);
        }

        public static void Save(DataTable dtrecipe)
        {
            if (dtrecipe.Rows.Count == 0)
            {
                throw new Exception("Cannot call Recipe save method because there are no rows in the table");
            }
            DataRow r = dtrecipe.Rows[0];
            SQLUtility.SaveDataRow(r, "RecipeUpdate");
        }
      
        public static void Delete(DataTable dtrecipe)
        {
            int id = (int)dtrecipe.Rows[0]["recipeId"];
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@recipeId", id);
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}

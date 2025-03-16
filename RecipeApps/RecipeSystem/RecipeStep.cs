using System.Data;
using System.Data.SqlClient;

namespace RecipeSystem
{
    public class RecipeStep
    {
        public static DataTable LoadByRecipeId(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeDirectionGet");
            cmd.Parameters["@RecipeId"].Value = recipeid;
            return dt = SQLUtility.GetDataTable(cmd);
        }
        public static void SaveTable(DataTable dt, int recipeid)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["RecipeId"] = recipeid;
            }
            SQLUtility.SaveDataTable(dt, "RecipeDirectionUpdate");
        }

        public static void Delete(int directionid)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand("RecipeDirectionDelete");
            cmd.Parameters["@DirectionId"].Value = directionid;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}

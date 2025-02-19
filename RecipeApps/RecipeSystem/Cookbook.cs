using System.Data.SqlClient;
using System.Data;

namespace RecipeSystem
{
    public class Cookbook
    {
        public static DataTable Load(int cookbookid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand("CookbookGet");
            cmd.Parameters["@CookbookId"].Value = cookbookid;
            return SQLUtility.GetDataTable(cmd);
        }

        public static void Save(DataTable dtcookbook)
        {
            if (dtcookbook.Rows.Count == 0)
            {
                throw new Exception("Cannot call cookbook save method because there are no rows in the table");
            }
            DataRow r = dtcookbook.Rows[0];
            SQLUtility.SaveDataRow(r, "CookbookUpdate");

        }

        public static void Delete(DataTable dtcookbook)
        {
            int id = (int)dtcookbook.Rows[0]["CookbookId"];
            SqlCommand cmd = SQLUtility.GetSqlCommand("CookbookDelete");
            SQLUtility.SetParamValue(cmd, "@CookbookId", id);
            SQLUtility.ExecuteSQL(cmd);
        }

        public static DataTable GetDataList(string tablename, bool includeblank = false )
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

        public static int AutoCreateaCookbook(int userid)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand("AutoCreateaCookbook");
            SQLUtility.SetParamValue(cmd,"@UserId", userid);
            SQLUtility.ExecuteSQL(cmd);
            var cookbookId = (int)cmd.Parameters["@CookbookId"].Value;
            return cookbookId;
        }
    }
}

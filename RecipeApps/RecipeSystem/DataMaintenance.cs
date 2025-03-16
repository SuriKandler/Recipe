using System.Data.SqlClient;
using System.Data;


namespace RecipeSystem
{
    public static class DataMaintenance
    {
        public static DataTable GetDataList(string tablename, bool includeblank = false)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSqlCommand(tablename + "Get");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            if(includeblank == true)
            {
                SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            }
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable GetDataListNoParam(string sprocname)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(sprocname);
            return SQLUtility.GetDataTable(cmd);
        }

        public static void SaveDataList(DataTable dt, string tablename)
        {
            SQLUtility.SaveDataTable(dt, tablename + "Update");
        }

        public static void DeleteRow(string tablename, int id)
        {
            SqlCommand cmd = SQLUtility.GetSqlCommand(tablename + "Delete");
            SQLUtility.SetParamValue(cmd, $"@{tablename}Id", id);
            SQLUtility.ExecuteSQL(cmd);
        }      
    }
}

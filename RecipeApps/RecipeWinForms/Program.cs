using CPUFramework;
using Microsoft.VisualBasic.ApplicationServices;
using RecipeWinForms;

namespace RecipeWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            SQLUtility.ConnectionString = "Server = tcp:dev-sk.database.windows.net,1433; Initial Catalog = HeartyHearthDB; Persist Security Info = False; User ID = dev_login; Password = HAPpy372(3&; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";
            Application.Run(new frmSearch());
        }
    }
}

//SQLUtility.ConnectionString = "Server =.\\SQLExpress01; Database = HeartyHearthDB; Trusted_Connection = true";

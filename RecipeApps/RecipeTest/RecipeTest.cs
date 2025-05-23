using NUnit.Framework;
using RecipeSystem;
using System;
using System.Configuration;
using System.Data;

namespace RecipeTest
{
    public class RecipeTests
    {
        string devconnstring = ConfigurationManager.ConnectionStrings["devconn"].ConnectionString;
        string connstring = ConfigurationManager.ConnectionStrings["liveconn"].ConnectionString;
        //string testconnstring = ConfigurationManager.ConnectionStrings["unittestconn"].ConnectionString;
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString(connstring, true);
        }

        private DataTable GetDataTable(string sql)
        {
            DataTable dt = new();
            //DBManager.SetConnectionString(testconnstring, false);
            dt = SQLUtility.GetDataTable(sql);
            DBManager.SetConnectionString(connstring, false);
            return dt;
        }

        private int GetFirstColumnFirstRowValue(string sql)
        {
            int n = 0;
            //DBManager.SetConnectionString(testconnstring, false);
            n = SQLUtility.GetFirstColumnFirstRowValue(sql);
            DBManager.SetConnectionString(connstring, false);
            return n;
        }

        private void ExecuteSQL(string sql)
        {
            //DBManager.SetConnectionString(testconnstring, false);
            SQLUtility.ExecuteSQL(sql);
            DBManager.SetConnectionString(connstring, false);

        }

        [Test]
        [TestCase("04/07/2023", 85)]
        [TestCase("06/10/2021", 185)]
        [TestCase("11/09/2023", 126)]
        public void InsertNewRecipe(DateTime datedraft, int calories)
        {            
            int userid = GetFirstColumnFirstRowValue("select top 1 userid from users");
            Assume.That(userid > 0, "Can't run test no users in the DB");
            int cuisineid = GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "Can't run test no cuisines in the DB");

            int maxnumrecipe = GetFirstColumnFirstRowValue("select max(recipeid) from recipe");
            maxnumrecipe = maxnumrecipe + 1;
          
            TestContext.WriteLine("insert recipe with recipename = recipetest" + maxnumrecipe);
            bizRecipe rcp = new();
            rcp.UserId = userid;
            rcp.CuisineId = cuisineid;
            rcp.RecipeName = "recipetest" + maxnumrecipe;
            rcp.DateDraft = datedraft;
            rcp.DatePublished = datedraft.AddDays(35);
           // rcp.DateArchived = datedraft.AddDays(90);
            rcp.Calories = calories;
            rcp.RecipeStatus = "Archived";
            
            rcp.Save();
            
            int newid = GetFirstColumnFirstRowValue("select * from recipe where recipename = 'recipetest" + maxnumrecipe + "'");
            
            Assert.IsTrue(newid > 0, "recipe with recipename = recipetest" + maxnumrecipe + "is not found in db");
            TestContext.WriteLine("recipe with recipename = recipetest" + maxnumrecipe + "is found in db with pk value = " + newid);
           
        }

        [Test]       
        public void InsertNewRecipeWithSameName()
        {
            DataTable dt = GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int userid = GetFirstColumnFirstRowValue("select top 1 userid from users");
            Assume.That(userid > 0, "Can't run test no users in the DB");
            int cuisineid = GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "Can't run test no cuisines in the DB");

            string recipename = GetFirstColumnFirstRowValueAsString("select top 1 recipename from recipe");            

            TestContext.WriteLine("insert recipe with name " + recipename);
            r["userid"] = userid;
            r["cuisineid"] = cuisineid;
            r["recipename"] = recipename;
            r["datedraft"] = "04/07/2023";
            r["calories"] = "23";
            bizRecipe rcp = new();
            Exception ex = Assert.Throws<Exception>(() => rcp.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void ChangeCaloriesAmount()
        {
            int recipeid = GetExistingRecipeIdWithNoConnectingData();
            Assume.That(recipeid > 0, "No recipes in DB, can't run test");
            int calories = GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            TestContext.WriteLine("calories for recipeid " + recipeid + " is " + calories);
            calories = calories + 12;
            TestContext.WriteLine("change calories to " + calories);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["Calories"] = calories;
            bizRecipe rcp = new();
            rcp.Save(dt);

            int newcalories = GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assert.IsTrue(newcalories == calories, "Calories for recipe (" + recipeid + ") = " + newcalories);
            TestContext.WriteLine("Calories for recipe (" + recipeid + ") = " + newcalories);
        }

        [Test]
        public void ChangeToIncorrectCaloriesAmount()
        {
            int recipeid = GetExistingRecipeIdWithNoConnectingData();
            Assume.That(recipeid > 0, "No recipes in DB, can't run test");
            int calories = GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            TestContext.WriteLine("calories for recipeid " + recipeid + " is " + calories);
            calories = calories - calories;
            TestContext.WriteLine("change calories to " + calories);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["Calories"] = calories;
            bizRecipe rcp = new();
            Exception ex = Assert.Throws<Exception>(() => rcp.Save(dt));
            TestContext.WriteLine(ex.Message);
        }

        private DataTable GetRcpForDelete()
        {
            string sql = @"
                select top 1 r.recipeid, recipename 
                from recipe r 
                left join recipeingredient ri 
                on ri.recipeid = r.recipeid 
                left join recipedirection rd 
                on rd.recipeid = r.recipeid 
                where ri.recipeingredientid is null 
                and rd.directionid is null";
            DataTable dt = GetDataTable(sql);
            return dt;
        }

        
        [Test]
        public void DeleteRecipe()
        {
            DataTable dt = GetRcpForDelete();
            int recipeid = 0;
            string recdesc = "";
            if(dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recdesc = dt.Rows[0]["recipename"].ToString();
            }                
            Assume.That(recipeid > 0, "No recipes without recipe ingredients in DB, can't run test");
            TestContext.WriteLine("existing recipe without recipe ingredients, with id = " + recipeid);
            TestContext.WriteLine("ensure that app can delete " + recipeid);
            bizRecipe rcp = new();
            rcp.Load(recipeid);
            rcp.Delete();
            DataTable dtafterdelete = GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "record with recipeid " + recipeid + "exists in DB");
            TestContext.WriteLine("Record with recipeid " + recipeid + " does not exist in DB");
        }
        [Test]
        public void DeleteRecipeById()
        {
            DataTable dt = GetRcpForDelete();
            int recipeid = 0;
            string recdesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recdesc = dt.Rows[0]["recipename"].ToString();
            }
            Assume.That(recipeid > 0, "No recipes without recipe ingredients in DB, can't run test");
            TestContext.WriteLine("existing recipe without recipe ingredients, with id = " + recipeid);
            TestContext.WriteLine("ensure that app can delete " + recipeid);
            bizRecipe rcp = new();
            rcp.Delete(recipeid);
            DataTable dtafterdelete = GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "record with recipeid " + recipeid + "exists in DB");
            TestContext.WriteLine("Record with recipeid " + recipeid + " does not exist in DB");
        }
        [Test]
        public void DeleteRecipeByDataTable()
        {
            DataTable dt = GetRcpForDelete();
            int recipeid = 0;
            string recdesc = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recdesc = dt.Rows[0]["recipename"].ToString();
            }
            Assume.That(recipeid > 0, "No recipes without recipe ingredients in DB, can't run test");
            TestContext.WriteLine("existing recipe without recipe ingredients, with id = " + recipeid);
            TestContext.WriteLine("ensure that app can delete " + recipeid);
            bizRecipe rcp = new();
            rcp.Delete(dt);
            DataTable dtafterdelete = GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "record with recipeid " + recipeid + "exists in DB");
            TestContext.WriteLine("Record with recipeid " + recipeid + " does not exist in DB");
        }

        [Test]

    public void DeleteRecipeEnforceBusinessRules()
        {
            string sql = @"
select top 1 r.recipeid, r.recipename 
from recipe r 
where (r.RecipeStatus = 'Archived' and getdate() - r.DateArchived < 30) 
or r.RecipeStatus = 'Published'
";
            DataTable dt = GetDataTable(sql);
            int recipeid = 0;
            string recipename = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipename = dt.Rows[0]["recipename"].ToString();
            }
            Assume.That(recipeid > 0, "No recipes conflict with the business rules in the DB, can't run test");
            TestContext.WriteLine("existing recipe blocked by the business rule, " + recipename + " with id = " + recipeid);
            TestContext.WriteLine("ensure that app cannot delete " + recipeid);
            bizRecipe rcp = new();
            Exception ex = Assert.Throws<Exception>(() => rcp.Delete(dt));

            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void DeleteRecipeWithConnectedData()
        {
            DataTable dt = GetDataTable("select top 1 r.recipeid, recipename from recipe r join recipeingredient ri on ri.recipeid = r.recipeid");
            int recipeid = 0;
            string recipename = "";
            if (dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                recipename = dt.Rows[0]["recipename"].ToString();
            }
            Assume.That(recipeid > 0, "No recipe with connecting data, in DB, can't run test");
            TestContext.WriteLine("existing recipe with recipe ingredients - connecting data, " + recipename +  " with id = " + recipeid);
            TestContext.WriteLine("ensure that app cannot delete " + recipeid);
            bizRecipe rcp = new();
            Exception ex = Assert.Throws<Exception>(() => rcp.Delete(dt));

            TestContext.WriteLine(ex.Message);
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipes in DB, can't run test");
            TestContext.WriteLine("existing recipe with id = " + recipeid);
            TestContext.WriteLine("Ensure that app loads recipe " + recipeid);
            bizRecipe rcp = new();
            rcp.Load(recipeid);
            int loadedid = rcp.RecipeId;
            string recipename = rcp.RecipeName;

            Assert.IsTrue(loadedid == recipeid && recipename != "", loadedid + " <> " + recipeid + " RecipeName = " + recipename);
            TestContext.WriteLine("Loaded recipe (" + loadedid + ") RecipeName = " + recipename);
        }

        [Test]
        public void GetListOfUsers()
        {
            int usercount = GetFirstColumnFirstRowValue("select total = count(*) from users");
            Assume.That(usercount > 0, "No users in DB, can't test");
            TestContext.WriteLine("Num of users in DB = " + usercount);
            TestContext.WriteLine("Ensure that num of rows returned by app matches " + usercount);
            bizUser p = new();
            var lst = p.GetList();
            Assert.IsTrue(lst.Count == usercount, "Num rows returned by app (" +  lst.Count + ") <> " + usercount);
            TestContext.WriteLine("Number of rows in Users returned by app = " + lst.Count);
        }

        [Test]
        public void GetListOfRecipes()
        {
            int recipecount = GetFirstColumnFirstRowValue("select total = count(*) from recipe");
            Assume.That(recipecount > 0, "No recipes in DB, can't test");
            TestContext.WriteLine("Num of recipes in DB = " + recipecount);
            TestContext.WriteLine("Ensure that num of rows returned by app matches " + recipecount);
            bizRecipe p = new();
            var lst = p.GetList();
            Assert.IsTrue(lst.Count == recipecount, "Num rows returned by app (" + lst.Count + ") <> " + recipecount);
            TestContext.WriteLine("Number of rows in recipe returned by app = " + lst.Count);
        }
        [Test]
        public void SearchRecipes()
        {
            string recipename = "e";
            int recipecount = GetFirstColumnFirstRowValue($"select total = count(*) from recipe where recipename like '%{recipename}%'");
            TestContext.WriteLine("Num of search results in DB = " + recipecount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + recipecount);
            bizRecipe p = new();
            List<bizRecipe> lst = p.Search(recipename);
            Assert.IsTrue(lst.Count == recipecount, "num rows returned by search (" + lst.Count + ") <> " + recipecount);
            TestContext.WriteLine("Number of rows in search results return by app = " + lst.Count);
        }
        [Test]
        public void GetListOfIngredients()
        {
            int ingredientcount = GetFirstColumnFirstRowValue("select total = count(*) from ingredient");
            Assume.That(ingredientcount > 0, "No ingredients in DB, can't test");
            TestContext.WriteLine("Num of ingredients in DB = " + ingredientcount);
            TestContext.WriteLine("Ensure that num of rows returned by app matches " + ingredientcount);
            bizIngredient p = new();
            var lst = p.GetList();
            Assert.IsTrue(lst.Count == ingredientcount, "Num rows returned by app (" + lst.Count + ") <> " + ingredientcount);
            TestContext.WriteLine("Number of rows in ingredient returned by app = " + lst.Count);
        }
        [Test]
        public void SearchIngredients()
        {
            string ingredientname = "e";
            int ingredientcount = GetFirstColumnFirstRowValue($"select total = count(*) from ingredient where ingredientname like '%{ingredientname}%'");
            TestContext.WriteLine("Num of search results in DB = " + ingredientcount);
            TestContext.WriteLine("Ensure that num of rows return by app matches " + ingredientcount);
            bizIngredient p = new();
            List<bizIngredient> lst = p.Search(ingredientname);
            Assert.IsTrue(lst.Count == ingredientcount, "num rows returned by search (" + lst.Count + ") <> " + ingredientcount);
            TestContext.WriteLine("Number of rows in search results return by app = " + lst.Count);
        }

        [Test]
        public void SaveMultipleRows()
        {
            string sql = "delete cuisine where title in ('Testcuisine1','Testcuisine2')";
            ExecuteSQL(sql);
            sql = "update cuisine set title = 'Originalcuisine1' where title = 'TestChange1'";
            ExecuteSQL(sql);

            DataTable dt = DataMaintenance.GetDataList("cuisine");
            var dr = dt.Rows.Add();
            dr["title"] = "Testcuisine1";
            dr = dt.Rows.Add();
            dr["title"] = "Testcuisine2";
            dt.Rows[0]["title"] = "TestChange1";
            SQLUtility.SaveDataTable(dt, "cuisineUpdate");

            sql = "select * from cuisine where title in('Testcuisine1','Testcuisine2','TestChange1')";
            DataTable dtcheck = GetDataTable(sql);
            Assert.IsTrue(dtcheck.Rows.Count == 3, $"num rows of dtcheck is {dtcheck.Rows.Count} not 3 rows");
            TestContext.WriteLine($"num rows of dtcheck should be 3 and it is {dtcheck.Rows.Count}");
        }



        private string GetFirstColumnFirstRowValueAsString(string sql)
        {
            string s = "";

            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count > 0 && dt.Columns.Count > 0)
            {
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    s = dt.Rows[0]["RecipeName"].ToString();
                }
            }

            return s;


        }

        private int GetExistingRecipeId()
        {
            return GetFirstColumnFirstRowValue("select top 1 r.recipeid from recipe r");
            
        }

        private int GetExistingRecipeIdWithNoConnectingData()
        {
            return GetFirstColumnFirstRowValue("select top 1 r.recipeid from recipe r left join recipeingredient ri on ri.recipeid = r.recipeid where ri.recipeingredientid is null");
        }

        [Test]
        public void CheckTestEnvironmentConfiguration()
        {
            string liveConnStr = ConfigurationManager.ConnectionStrings["liveconn"]?.ConnectionString;
            string devConnStr = ConfigurationManager.ConnectionStrings["devconn"]?.ConnectionString;

            TestContext.WriteLine($"Current user: {Environment.UserName}");
            TestContext.WriteLine($"Machine name: {Environment.MachineName}");

            if (string.IsNullOrWhiteSpace(liveConnStr))
            {
                TestContext.WriteLine("liveconn connection string is NULL or empty.");
            }
            else
            {
                TestContext.WriteLine("liveconn connection string:");
                TestContext.WriteLine(liveConnStr);
            }

            if (string.IsNullOrWhiteSpace(devConnStr))
            {
                TestContext.WriteLine("devconn connection string is NULL or empty.");
            }
            else
            {
                TestContext.WriteLine("devconn connection string:");
                TestContext.WriteLine(devConnStr);
            }

            // Try to open a connection to test access
            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(liveConnStr))
                {
                    conn.Open();
                    TestContext.WriteLine("Successfully connected to database using liveconn.");
                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("FAILED to connect using liveconn.");
                TestContext.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
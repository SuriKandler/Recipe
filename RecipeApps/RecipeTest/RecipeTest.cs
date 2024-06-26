using NUnit.Framework;
using System;
using System.Data;

namespace RecipeTest
{
    public class RecipeTests
    {
        [SetUp]
        public void Setup()
        {
            DBManager.SetConnectionString("Server = tcp:dev-sk.database.windows.net,1433; Initial Catalog = HeartyHearthDB; Persist Security Info = False; User ID = dev_login; Password = HAPpy372(3&; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30");
        }
           
        [Test]
        [TestCase("04/07/2023", 85)]
        [TestCase("06/10/2021", 185)]
        [TestCase("11/09/2023", 126)]
        public void InsertNewRecipe(DateTime datedraft, int calories)
        {
            DataTable dt = SQLUtility.GetDataTable("select * from recipe where recipeid = 0");
            DataRow r = dt.Rows.Add();
            Assume.That(dt.Rows.Count == 1);
            int userid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 userid from users");
            Assume.That(userid > 0, "Can't run test no users in the DB");
            int cuisineid = SQLUtility.GetFirstColumnFirstRowValue("select top 1 cuisineid from cuisine");
            Assume.That(cuisineid > 0, "Can't run test no cuisines in the DB");

            int maxnumrecipe = SQLUtility.GetFirstColumnFirstRowValue("select max(recipeid) from recipe");
            maxnumrecipe = maxnumrecipe + 1;

          
            TestContext.WriteLine("insert recipe with recipename = recipetest" + maxnumrecipe); 
            r["userid"] = userid;
            r["cuisineid"] = cuisineid;
            r["recipename"] = "recipetest" + maxnumrecipe;
            r["datedraft"] = datedraft;
            r["calories"] = calories;
            Recipe.Save(dt);
            
            int newid = SQLUtility.GetFirstColumnFirstRowValue("select * from recipe where recipename = 'recipetest" + maxnumrecipe + "'");
            Assert.IsTrue(newid > 0, "recipe with recipename = recipetest" + maxnumrecipe + "is not found in db");
            TestContext.WriteLine("recipe with recipename = recipetest" + maxnumrecipe + "is found in db with pk value = " + newid);
           
        }

        [Test]
        public void ChangeCaloriesAmount()
        {
            int recipeid = GetExistingRecipeIdWithNoConnectingData();
            Assume.That(recipeid > 0, "No recipes in DB, can't run test");
            int calories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            TestContext.WriteLine("calories for recipeid " + recipeid + " is " + calories);
            calories = calories + 12;
            TestContext.WriteLine("change calories to " + calories);

            DataTable dt = Recipe.Load(recipeid);
            dt.Rows[0]["Calories"] = calories;
            Recipe.Save(dt);

            int newcalories = SQLUtility.GetFirstColumnFirstRowValue("select calories from recipe where recipeid = " + recipeid);
            Assert.IsTrue(newcalories == calories, "Calories for recipe (" + recipeid + ") = " + newcalories);
            TestContext.WriteLine("Calories for recipe (" + recipeid + ") = " + newcalories);
        }

        [Test]
        public void DeleteRecipe()
        {

            DataTable dt = SQLUtility.GetDataTable("select top 1 r.recipeid, recipename from recipe r left join recipeingredient ri on ri.recipeid = r.recipeid where ri.recipeingredientid is null");
            int recipeid = 0;
            //string recdesc = "";
            if(dt.Rows.Count > 0)
            {
                recipeid = (int)dt.Rows[0]["recipeid"];
                //recdesc = dt.Rows[0]["recipename"].ToString();
            }                
            Assume.That(recipeid > 0, "No recipes without recipe ingredients in DB, can't run test");
            TestContext.WriteLine("existing recipe without recipe ingredients, with id = " + recipeid);
            TestContext.WriteLine("ensure that app can delete " + recipeid);
            Recipe.Delete(dt);
            DataTable dtafterdelete = SQLUtility.GetDataTable("select * from recipe where recipeid = " + recipeid);
            Assert.IsTrue(dtafterdelete.Rows.Count == 0, "record with recipeid " + recipeid + "exists in DB");
            TestContext.WriteLine("Record with recipeid " + recipeid + " does not exist in DB");
        }

        [Test]
        public void LoadRecipe()
        {
            int recipeid = GetExistingRecipeId();
            Assume.That(recipeid > 0, "No recipes in DB, can't run test");
            TestContext.WriteLine("existing recipe with id = " + recipeid);
            TestContext.WriteLine("Ensure that app loads recipe " + recipeid);
            DataTable dt = Recipe.Load(recipeid);
            int loadedid = (int)dt.Rows[0]["recipeid"];
            Assert.IsTrue(loadedid == recipeid, (int)dt.Rows[0]["recipeid"] + " <> " + recipeid);
            TestContext.WriteLine("Loaded recipe (" + loadedid + ")");
        }

        [Test]
        public void GetListOfUsers()
        {
            int usercount = SQLUtility.GetFirstColumnFirstRowValue("select total = count(*) from users");
            Assume.That(usercount > 0, "No users in DB, can't test");
            TestContext.WriteLine("Num of users in DB = " + usercount);
            TestContext.WriteLine("Ensure that num of rows returned by app matches " + usercount);
            DataTable dt = Recipe.GetUsersList();
            Assert.IsTrue(dt.Rows.Count == usercount, "Num rows returned by app (" +  dt.Rows.Count + ") <> " + usercount);
            TestContext.WriteLine("Number of rows in Users returned by app = " + dt.Rows.Count);
        }

        private int GetExistingRecipeId()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 recipeid from recipe");
            
        }

        private int GetExistingRecipeIdWithNoConnectingData()
        {
            return SQLUtility.GetFirstColumnFirstRowValue("select top 1 r.recipeid from recipe r left join recipeingredient ri on ri.recipeid = r.recipeid where ri.recipeingredientid is null");
        }
    }
}
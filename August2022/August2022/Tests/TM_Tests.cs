
using August2022.Pages;
using August2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace August2022.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests:CommonDriver
     {


        [SetUp]
        public void LoginActions()
        {
            //Open Chrome browser
            driver = new ChromeDriver();
            
            //Login page object intialisation and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj.LoginSteps(driver);

            // Home page object intialisation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GotoTMPage(driver);
        }

        [Test, Order(1), Description("Check if the user is able to create a TM record")]
        public void CreateTMTest()
        {
            // TM page object intialisation and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTM(driver);

        }

        [Test, Order(2), Description("Check if the user is able to edit a exsisting TM record")]
        public void EditTMTest()
        {
            
            //TM page object intialisation
            TMPage tmPageObj = new TMPage();
            //Edit TM
          // tmPageObj.EditTM(driver);

        }

        [Test, Order(3), Description("Check if the user is able to Delete a exsisting TM record")]
        public void DeleteTMTest()
        {

            // Delete TM
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteTM(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
           driver.Quit();

        }

        

        

        

        

        
    }
}

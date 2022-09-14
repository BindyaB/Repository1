using August2022.Pages;
using August2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace August2022.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {

        LoginPage loginpageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();


        [Given(@"I logged into turnup portal successfully")]
        public void GivenILoggedIntoTurnupPortalSuccessfully()
        {
            driver = new ChromeDriver();
            loginpageObj.LoginSteps(driver);

        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            homePageObj.GotoTMPage(driver);
        }

        [When(@"I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            tmPageObj.CreateTM(driver);
        }

        [Then(@"The record should be created sucessfully")]
        public void ThenTheRecordShouldBeCreatedSucessfully()
        {
            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "Time 1009", "Actual code and expected code does not match");
            Assert.That(newDescription == "August 2022", "Actual Description and expected Description does not match");
            Assert.That(newPrice == "$345.00", "Actual price and expected price does not match");



        }

        [When(@"I update '([^']*)', '([^']*)' and '([^']*)' on an exsisting time and material record")]
         public void WhenIUpdateAndOnAnExsistingTimeAndMaterialRecord(string description, string code, string price)
         {
            tmPageObj.EditTM(driver, description, code, price);
         }

       

        [Then(@"The record should have the updated '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string description, string code, string price)
        {
            string changeDescription = tmPageObj.GetEditDescription(driver);
            string changeCode = tmPageObj.GetEditCode(driver);
            string changePrice = tmPageObj.GetEditPrice(driver);

            Assert.That(changeDescription == description, "Actual Description and expected Description does not match");
            Assert.That(changeCode == code, "Actual code and expected code does not match");
            Assert.That(changePrice == price, "Actual price and expected price does not match");
        }






    }
}

using August2022.Pages;
using August2022.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2022.Tests
{
    public class Employee_Tests:CommonDriver
    {
        public void LoginProcess()
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

        public void CreateNewEmployee()
        {

        }

        public void EditEmployee()
        {

        }

        public void DeleteEmployee()
        {

        }
    }
     
}

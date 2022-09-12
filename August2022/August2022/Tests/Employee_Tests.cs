using August2022.Pages;
using August2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace August2022.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employee_Tests:CommonDriver
    {
        [SetUp]
        public void LoginProcess()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //Login page object intialisation and definition
            LoginPage loginpageObj = new LoginPage();
            loginpageObj.LoginSteps(driver);

            // Home page object intialisation and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GotoEmployeePage(driver);
        }

        [Test, Order(1), Description("Check if the user is able to user is able to create a new record ")]
        public void CreateEmployeeTest()
        {
            
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.CreateEmployee(driver); 
        }

        [Test, Order(2), Description("Check if the employee is able to edit an exsisting record")]
        public void EditEmployeeTest()
        {
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.EditEmployee(driver);
        }
        [Test, Order(3), Description("Check if the user is able to Delete exsisting record")]

        public void DeleteEmployeeTest()
        {

            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.DeleteEmployee(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            //driver.Quit();
        }
    }
     
}

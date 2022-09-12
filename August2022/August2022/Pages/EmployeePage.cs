using August2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace August2022.Pages
{
    public class EmployeePage
    {

        public void CreateEmployee(IWebDriver driver)
        {

            //Click on the create button

            IWebElement createButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createButton.Click();

            //Enter name
            IWebElement nameTextBox = driver.FindElement(By.Id("Name"));
            nameTextBox.SendKeys("Masha");

            //Enter username

            IWebElement usernameTextBox = driver.FindElement(By.Id("Username"));
            usernameTextBox.SendKeys("Masha342");

            //Click on Edit contact
            IWebElement editContactbutton = driver.FindElement(By.Id("EditContactButton"));
            editContactbutton.Click();
            Thread.Sleep(2000);

            driver.SwitchTo().Frame(0);
            //Console.WriteLine("window = " + title);


            Thread.Sleep(2000);


            //Enter First Name, Last Name and Preferred Name

            IWebElement firstNameTextbox = driver.FindElement(By.Id("FirstName"));
            firstNameTextbox.Click();
            firstNameTextbox.SendKeys("Nella");
            IWebElement lastNameTextBox = driver.FindElement(By.Id("LastName"));
            lastNameTextBox.SendKeys("Nat");
            IWebElement preferredNameTextbox = driver.FindElement(By.Id("PreferedName"));
            preferredNameTextbox.SendKeys("Nat");


            //Enter Phone Mobile, Email Fax
            IWebElement phoneTextbox = driver.FindElement(By.Id("Phone"));
            phoneTextbox.SendKeys("345689");
            IWebElement mobileTextBox = driver.FindElement(By.Id("Mobile"));
            mobileTextBox.SendKeys("2679065");
            IWebElement emailTextbox = driver.FindElement(By.Id("email"));
            emailTextbox.SendKeys("nellanat@youme.com");
            IWebElement faxTextBox = driver.FindElement(By.Id("Fax"));
            faxTextBox.SendKeys("345688");

            //Enter street, city, postcode and country
            IWebElement streetTextBox = driver.FindElement(By.Id("Street"));
            streetTextBox.SendKeys("25, Shirmp rd");
            IWebElement cityTextBox = driver.FindElement(By.Id("City"));
            cityTextBox.SendKeys("Nottingham");
            IWebElement postcodeTextBox = driver.FindElement(By.Id("Postcode"));
            postcodeTextBox.SendKeys("5600");
            IWebElement countryTextBox = driver.FindElement(By.Id("Country"));
            countryTextBox.SendKeys("Malaysia");

            //save contact

            IWebElement saveContactButton = driver.FindElement(By.Id("submitButton"));
            saveContactButton.Click();


            //Enter password and re-type password

            driver.SwitchTo().DefaultContent();

            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
            passwordTextBox.Click();
            passwordTextBox.SendKeys("Moanard#45");
            IWebElement retypepasswordTextBox = driver.FindElement(By.Id("RetypePassword"));
            retypepasswordTextBox.SendKeys("Moanard#45");

            //Check on Admin

            IWebElement adminCheckboxButton = driver.FindElement(By.Id("IsAdmin"));
            adminCheckboxButton.Click();

            //Enter Vehicles

            IWebElement vehicleTextBox = driver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[7]/div/span[1]/span/input"));
            vehicleTextBox.SendKeys("Car");


            //Enter Groups

            IWebElement groupsTextBox = driver.FindElement(By.XPath("//*[@id='UserEditForm']/div/div[8]/div/div/div[1]"));
            vehicleTextBox.SendKeys("First");

            //Click on the save button

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Click on back to list
            IWebElement backToListButton = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            backToListButton.Click();

            //Go to last page
            Thread.Sleep(5000);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            //Check if new employee is added

            IWebElement newEmployeeName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newUsername = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]"));

            Assert.That(newEmployeeName.Text == "Masha", "Employee record not created");
            Assert.That(newUsername.Text == "Masha342", "Employee record not created");



        } 

        public void EditEmployee(IWebDriver driver)
        {
            Thread.Sleep(5000);
            //Go to last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            //Select Employee and click edit button

            IWebElement editEmployee = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
            editEmployee.Click();

            //Change name and user name
            IWebElement editName = driver.FindElement(By.Id("Name"));
            editName.Clear();
            editName.SendKeys("Miriam");
            IWebElement editUserName = driver.FindElement(By.Id("Username"));
            editUserName.Clear();
            editUserName.SendKeys("Miriam324");

            //Click Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Click on the back to list
            IWebElement backToListButton = driver.FindElement(By.XPath("//*[@id='container']/div/a"));
            backToListButton.Click();
            driver.Navigate().Refresh();

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='usersGrid']/div[4]/a[4]/span", 5);

            try
            {
                //Go to last page
                goToLastPageButton= driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
                goToLastPageButton.Click();
            }

            catch(Exception ex)
            {
                Assert.Fail("Button can't be clicked", ex.Message);
            }
            

            //Check if the employee details have been changed
            IWebElement editedEmployeeName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedNewUsername = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]"));

            Assert.That(editedEmployeeName.Text == "Miriam", "The changes have not been made");
            Assert.That(editedNewUsername.Text == "Miriam324", "The changes have not been made");

        }

        public void DeleteEmployee(IWebDriver driver)
        {
            //Go to last page

            Thread.Sleep(5000);

            IWebElement goToLastPageButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            //Click on the delete button
            IWebElement deleteEmployee = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
            deleteEmployee.Click();

            //Click okay on the alert box
            driver.SwitchTo().Alert().Accept();

            //Refresh Page
            driver.Navigate().Refresh();

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='usersGrid']/div[4]/a[4]/span", 5);


            //Check if employee details are deleted
            goToLastPageButton = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement lastEmployeeName = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement lastUsername = driver.FindElement(By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[2]")); 
            
            Assert.That(lastEmployeeName.Text != "Miriam", "Employee name not deleted");
            Assert.That(lastUsername.Text != "Miriam324", "Employee username not deleted");
        }

    }
}

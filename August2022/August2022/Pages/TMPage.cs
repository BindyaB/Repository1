using OpenQA.Selenium;


namespace August2022.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // Select Time and Material Option

            IWebElement tmOptions = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOptions.Click();

            //Click on the Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            //Click on the Type code drop down button
            IWebElement typecodeDropdownButton = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typecodeDropdownButton.Click();

            //Select time option
            Thread.Sleep(1000);
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();

            //Input Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("Time 1009");

            //Input Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("August 2022");
            //Input Price
            IWebElement priceTemp = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTemp.Click();
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("345");

            //Click on Save
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Go to last page
            Thread.Sleep(3000);
            IWebElement gotoLastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastpageButton.Click();

            //Check if the new entry has been made
            IWebElement newRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (newRecord.Text == "Time 1009")
            {
                Console.WriteLine(" Record Entered Sucessfully, Test passed");
            }
            else
            {
                Console.WriteLine("Record Not found, Test Failed");
            }

        }
        public void EditTM(IWebDriver driver)
        {
            // choose record and click on the edit button
            Thread.Sleep(5000);
            IWebElement editRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editRecord.Click();

            //Change Description
            Thread.Sleep(5000);
            IWebElement newDescription = driver.FindElement(By.Id("Description"));
            newDescription.Clear();
            newDescription.SendKeys("August 27");

            //Click on Save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            //Check if the changes have been made
            Thread.Sleep(10000);
            IWebElement editGotoLastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            editGotoLastpageButton.Click();

            Thread.Sleep(5000);
            IWebElement changeRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            if (changeRecord.Text == "August 27")
            {
                Console.WriteLine("Record Changed Successfully. Test Passed");
            }
            else
            {
                Console.WriteLine(changeRecord.Text);
                Console.WriteLine("Change not recorded. Test Failed");
            }

        }
        public void DeleteTM(IWebDriver driver)
        {
            // Delete a record
            IWebElement deleteGoTolastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            deleteGoTolastpageButton.Click();

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            //click on the prompt button
            driver.SwitchTo().Alert().Accept();

            //check if the data is deleted
            driver.Navigate().Refresh();

            Thread.Sleep(4000);
            IWebElement refreshGoTolastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            refreshGoTolastpageButton.Click();
            IWebElement deleteRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));


            if (deleteRecord.Text == "Time 1009")
            {
                Console.WriteLine(deleteRecord.Text);
                Console.WriteLine("Record not Deleted. Test Failed");
            }

            else
            {
                Console.WriteLine(deleteRecord.Text);
                Console.WriteLine("Record Deleted. Test Passed");
            }
        }
    }
}

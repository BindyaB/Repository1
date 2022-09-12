using NUnit.Framework;
using OpenQA.Selenium;


namespace August2022.Pages
{
    public class TMPage
    {
        
        public void CreateTM(IWebDriver driver)
        {
            


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
            Thread.Sleep(7000);
            IWebElement gotoLastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastpageButton.Click();
                                     
        }

        public string GetCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }
        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }
        public void EditTM (IWebDriver driver, string description, string code, string price)
        {
            
            // Select Time and Material Option

            //IWebElement tmOptions = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            //tmOptions.Click();

            Thread.Sleep(7000);
            
            //Go to last page

            IWebElement gotoLastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
             gotoLastpageButton.Click();

            // choose record and click on the edit button
            IWebElement editRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
             editRecord.Click();
           
            //Edit Record
            Thread.Sleep(5000);

            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys(code);

            IWebElement editDescription = driver.FindElement(By.Id("Description"));
            editDescription.Clear();
            editDescription.SendKeys(description);

            IWebElement editTempPrice = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span"));
            editTempPrice.Click();

            IWebElement editPrice = driver.FindElement(By.Id("Price"));
            editPrice.Clear();
            editTempPrice.Click();
            editPrice.SendKeys(price);

            //Click on Save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            //Check if the changes have been made
            Thread.Sleep(10000);
            IWebElement editGotoLastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            editGotoLastpageButton.Click();

            Thread.Sleep(5000);
            
                
                        
        }

        public string GetEditDescription(IWebDriver driver)
        {
            IWebElement changeDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return changeDescription.Text;

        }
        public string GetEditCode(IWebDriver driver)
        {
            IWebElement changeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return changeCode.Text;
        }
        public string GetEditPrice(IWebDriver driver)
        {
            IWebElement changePrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            return changePrice.Text;

        }

        public void DeleteTM(IWebDriver driver)
        {
            // Select Time and Material Option

            IWebElement tmOptions = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOptions.Click();

            Thread.Sleep(7000);

            IWebElement gotoLastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastpageButton.Click();

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
            IWebElement deleteCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement deleteDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement deletePrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            Assert.That(deleteCode.Text != "Time 1009", "Record not Deleted");
            Assert.That(deleteDescription.Text != "August 27", "Record not Deleted");
            Assert.That(deletePrice.Text != "$97.00", "Record not Deleted");

        }
        }
    }



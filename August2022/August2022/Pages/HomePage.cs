using OpenQA.Selenium;


namespace August2022.Pages
{
    public class HomePage
    {
        public void GotoTMPage(IWebDriver driver)
        {
            // Click on the Administration Drop down button
            IWebElement administrationDropdownbutton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdownbutton.Click();

        }
    }
}

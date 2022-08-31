using OpenQA.Selenium;


namespace August2022.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            //Launch Turnup Portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(1000);

            //Identify the username textbox and enter valid user name
            IWebElement UsernameTextbox = driver.FindElement(By.Id("UserName"));
            UsernameTextbox.SendKeys("hari");

            //Identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            //Identify Login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();
        }
    }
}

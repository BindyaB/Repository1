using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//Open Chrome browser

IWebDriver driver = new ChromeDriver();
driver.Manage().Window.Maximize();

//Launch Turnup Portal
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

//Identify the username textbox and enter valid user name
IWebElement UsernameTextbox = driver.FindElement(By.Id("UserName"));
UsernameTextbox.SendKeys("hari");

//Identify password textbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//Identify Login button and click on it
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
loginButton.Click();

//Check if user has logged in sucessfully
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("Logged in Successfully, Test Passed");
}
else
{
    Console.WriteLine("Login Failed, Test Failed");
}
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//Open Chrome browser

IWebDriver driver = new ChromeDriver();
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
// Click on the Administration Drop down button
IWebElement administrationDropdownbutton = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
administrationDropdownbutton.Click();

//Select Time and Material Option
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


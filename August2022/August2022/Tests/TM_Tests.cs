using August2022.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//Open Chrome browser

IWebDriver driver = new ChromeDriver();

//Login page object intialisation and definition
LoginPage loginpageObj = new LoginPage();
loginpageObj.LoginSteps(driver);

// Home page object intialisation and definition
HomePage homePageObj = new HomePage();
homePageObj.GotoTMPage(driver);

// TM page object intialisation and definition
TMPage tmPageObj = new TMPage();
tmPageObj.CreateTM(driver);

//Edit TM
tmPageObj.EditTM(driver);

//Delete TM
tmPageObj.DeleteTM(driver);




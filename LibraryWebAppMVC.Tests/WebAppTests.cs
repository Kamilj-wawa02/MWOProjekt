using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace LibraryWebAppMVC.Tests
{
    [TestClass]
    public class WebAppTests
    {
        private IWebDriver Driver;
        private static string APP_URL = "https://localhost:7255/LibraryAPI";

        [TestInitialize]
        public void Initialize()
        {
            //ChromeOptions option = new ChromeOptions();
            //option.AddArguments("--headless");
            ////option.AddArgument("--remote-debugging-port=9222");
            //option.AddArgument("--whitelisted-ips");
            ////new DriverManager().SetUpDriver(new ChromeConfig());
            //Console.WriteLine("Setup chrome driver...");
            //Driver = new ChromeDriver(option);
            //Thread.Sleep(2000);



            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("--headless");
            Console.WriteLine("Setup Firefox driver...");
            Driver = new FirefoxDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Quit();
        }

        [TestMethod]
        public void T01_CreateTest()
        {
            Driver.Navigate().GoToUrl(APP_URL + "/Create");
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("#Title")).SendKeys("TestTitle");
            Driver.FindElement(By.CssSelector("#Author")).SendKeys("TestAuthor");
            Driver.FindElement(By.CssSelector("#Description")).SendKeys("TestDescription");
            Driver.FindElement(By.CssSelector("input[value='Create']")).Click();
            Thread.Sleep(1000);
            IWebElement tableRecord = Driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitle" + "')]"));
            Assert.IsTrue(tableRecord.Displayed);
        }

    }
}
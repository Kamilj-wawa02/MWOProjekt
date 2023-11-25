using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace LibraryWebAppMVC.Tests
{
    [TestClass]
    public class WebAppTests
    {
        private IWebDriver driver;
        private static string APP_URL = "https://localhost:7255/LibraryAPI";

        [TestInitialize]
        public void Initialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(options);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void T01_CreateTest()
        {
            driver.Navigate().GoToUrl(APP_URL + "/Create");
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("#Title")).SendKeys("TestTitle");
            driver.FindElement(By.CssSelector("#Author")).SendKeys("TestAuthor");
            driver.FindElement(By.CssSelector("#Description")).SendKeys("TestDescription");
            driver.FindElement(By.CssSelector("input[value='Create']")).Click();
            Thread.Sleep(1000);
            IWebElement tableRecord = driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitle" + "')]"));
            Assert.IsTrue(tableRecord.Displayed);

            // TODO: more to do
            // 
            // 
            // 
        }

    }
}
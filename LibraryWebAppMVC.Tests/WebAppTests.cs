using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


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
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--marionette-port=0");
            options.AddArgument("--headless");
            options.AcceptInsecureCertificates = true;
            Console.WriteLine("Setup Firefox Driver...");
            Driver = new FirefoxDriver(options);            
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
            Thread.Sleep(2000);
            Console.WriteLine("Redirected to /create");
            Console.WriteLine("URL: ", Driver.Url.ToString());
            Console.WriteLine("Content: " + Driver.PageSource.ToString());
            Driver.FindElement(By.CssSelector("#Title")).SendKeys("TestTitle");
            Driver.FindElement(By.CssSelector("#Author")).SendKeys("TestAuthor");
            Driver.FindElement(By.CssSelector("#Description")).SendKeys("TestDescription");
            Driver.FindElement(By.CssSelector("input[value='Create']")).Click();
            Thread.Sleep(1000);
            IWebElement tableRecord = Driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitle" + "')]"));
            Assert.IsTrue(tableRecord.Displayed);
        }

        
        [TestMethod]
        public void T02_GetTest()
        {
            Driver.Navigate().GoToUrl(APP_URL);
            Thread.Sleep(1000);
            IWebElement bookToEdit = Driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitle" + "')]"));
            IWebElement bookToEditParent = bookToEdit.FindElement(By.XPath("./.."));
            bookToEditParent.FindElement(By.CssSelector("a[aria-label='details']")).Click();
            Thread.Sleep(1000);
            IWebElement detailsRecord = Driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitle" + "')]"));
            Assert.IsTrue(detailsRecord.Displayed);
        }

        [TestMethod]
        public void T03_UpdateTest()
        {
            Driver.Navigate().GoToUrl(APP_URL);
            Thread.Sleep(1000);
            IWebElement bookToEdit = Driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitle" + "')]"));
            IWebElement bookToEditParent = bookToEdit.FindElement(By.XPath("./.."));
            bookToEditParent.FindElement(By.CssSelector("a[aria-label='edit']")).Click();
            Thread.Sleep(1000);
            IWebElement elementToEdit = Driver.FindElement(By.CssSelector("#Title"));
            elementToEdit.Clear();
            elementToEdit.SendKeys("TestTitleUpdated");
            Driver.FindElement(By.CssSelector("input[value='Save']")).Click();
            Thread.Sleep(1000);
            IWebElement tableRecord = Driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitleUpdated" + "')]"));
            Assert.IsTrue(tableRecord.Displayed);
        }

        [TestMethod]
        public void T04_DeleteTest()
        {
            Driver.Navigate().GoToUrl(APP_URL);
            Thread.Sleep(1000);
            IWebElement bookToDelete = Driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitle" + "')]"));
            IWebElement bookToDeleteParent = bookToDelete.FindElement(By.XPath("./.."));
            bookToDeleteParent.FindElement(By.CssSelector("a[aria-label='delete']")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("input[value='Delete']")).Click();
            Thread.Sleep(1000);
            Assert.ThrowsException<OpenQA.Selenium.NoSuchElementException>(() =>
                    Driver.FindElement(By.XPath("//*[contains(text(),'" + "TestTitle" + "')]")));
            
            // Added to test
            Assert.Fail();
        }

    }
}
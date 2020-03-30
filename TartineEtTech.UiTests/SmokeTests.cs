using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.IO;

namespace TartineEtTech.UiTests
{
    [TestClass]
    public class MySeleniumTests
    {
        private readonly string browser = "Chrome";
        private static string screenshotFolder = "Screenshots";
        private IWebDriver driver;
        private static string folderPath;
        private static TestContext testContext;

        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            testContext = context;
            CreateDirectoryIsNotExists();
        }

        private static void CreateDirectoryIsNotExists()
        {
            folderPath = $"{Directory.GetCurrentDirectory()}/{screenshotFolder}/";
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
        }

        [TestInitialize]
        public void Setup()
        {
            switch (browser)
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("headless");
                    chromeOptions.AddArguments("no-sandbox");
                    chromeOptions.AddArguments("disable-gpu");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }

        public TestContext TestContext
        {
            get
            {
                return testContext;
            }
            set
            {
                testContext = value;
            }
        }

        [TestMethod]
        public void SmokeTest()
        {
            Log.Write($"Go to url : {GetHomeUrl()}");
            driver.Navigate().GoToUrl(GetHomeUrl());
            TakeScreenshot("IndexScreen");
            Assert.IsTrue(driver.Title.Contains("Tartine & vous"), "Verified title of the page");

            driver.FindElement(By.Id("link-video")).Click();
            TakeScreenshot("Videos");
            Assert.IsTrue(driver.Title.Contains("Videos"), "Verified title of the page");

            driver.FindElement(By.Id("link-speakers")).Click();
            TakeScreenshot("Speakers");
            Assert.IsTrue(driver.Title.Contains("Invités"), "Verified title of the page");

            driver.FindElement(By.Id("link-coc")).Click();
            TakeScreenshot("CodeOfConduct");
            Assert.IsTrue(driver.Title.Contains("Code de conduite"), "Verified title of the page");
        }

        private void TakeScreenshot(string screenshotName)
        {
            var fileName = $"{screenshotName}-{DateTime.UtcNow.ToString("yyyyMMdd-HHmmss")}";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = $"{folderPath}/{fileName}.png";
            screenshot.SaveAsFile(path);
            this.TestContext.AddResultFile(path);
        }

        private string GetHomeUrl() => this.TestContext.Properties["webAppUrl"].ToString();
    }
}
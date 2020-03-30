using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Drawing;
using System.IO;
using System.Threading;

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
            var windowSize = new Size(1920, 1080);
            driver.Manage().Window.Size = windowSize;
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
            GoToUrlAndTakeScreenshot(GetHomeUrl());

            ClickOnListAndTakeScreenshot("link-video", "videos", "Videos");
            ClickOnListAndTakeScreenshot("link-speakers", "Speakers", "Invités");
            ClickOnListAndTakeScreenshot("link-coc", "CodeOfConduct", "Code de conduite");
            ClickOnListAndTakeScreenshot("link-activities", "Activities", "Activités");
        }

        private void ClickOnListAndTakeScreenshot(string linkId, string nameScenario, string pageTitle)
        {
            driver.FindElement(By.Id(linkId)).Click();
            Thread.Sleep(1000);
            TakeScreenshot(nameScenario);
            Assert.IsTrue(driver.Title.Contains(pageTitle), $"Verified title of the page {nameScenario}");
        }

        private void GoToUrlAndTakeScreenshot(string url)
        {
            driver.Navigate().GoToUrl(url);
            TakeScreenshot("IndexScreen");
            Assert.IsTrue(driver.Title.Contains("Tartine & vous"), "Verified title of the page index");
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
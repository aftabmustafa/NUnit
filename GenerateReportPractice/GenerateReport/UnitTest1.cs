using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace GenerateReport
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        IJavaScriptExecutor jsEx;

        public static ExtentTest Test;

        public static ExtentReports Extent;

        [SetUp]
        public void Initializer()
        {
            driver = new ChromeDriver();
            jsEx = (IJavaScriptExecutor)driver;
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            Extent = new ExtentReports();

            var HtmlReporter = new ExtentHtmlReporter(@"E:\ReportsResults\Report\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

            Extent.AttachReporter(HtmlReporter);
        }

        [Test]
        public void BrowserTest()
        {
            Test = null;
            Test = Extent.CreateTest("T001").Info("LoginTest");

            driver = new ChromeDriver();
            jsEx = (IJavaScriptExecutor)driver;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/login");

            Test.Log(Status.Info, "GoToUrl");

            string username = "aria";
            string password = "@riaLabel2022";

            driver.FindElement(By.Id("userName")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login")).Click();

            try
            {
                IWait<IWebDriver> Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));

                Wait.Until(driver1 => elementExists(By.XPath("//div[text()='Profile']")));

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        public bool elementExists(By by)
        {
            try
            {
                var x = driver.FindElement(by);
                return x.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            Extent.Flush();
        }



    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using DqLib;

namespace DemoQA
{
    [TestClass]
    public class UnitTest1 : SeleniumLib
    {
        public static ExtentTest Test;

        public static ExtentReports Extent;
       
        [SetUp]
        public void Initializer()
        {
            Driver = new ChromeDriver();
            Js = (IJavaScriptExecutor)Driver;
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            Extent = new ExtentReports();

            var HtmlReporter = new ExtentHtmlReporter(@"E:\ReportsResults\DemoQA\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");

            Extent.AttachReporter(HtmlReporter);
        }

        [Test, Order(1)]
        public void TextBoxTest()
        {
            Test = null;
            Test = Extent.CreateTest("TextBox").Info("TextBoxTesting");

            string FName = "Aftab Mustafa";
            string Email = "email@gmail.com";
            string CAddress = "Current Address 1";
            string PAddress = "Permanent Address 2";

            StartBrowser("https://demoqa.com/text-box");

            Test.Log(Status.Info, "GoToUrl");

            Sleep(1000);

            TextInput(By.Id("userName"), FName);

            Sleep(1000);

            TextInput(By.Id("userEmail"), Email);

            Sleep(1000);

            TextInput(By.Id("currentAddress"), CAddress);

            Sleep(1000);

            TextInput(By.Id("permanentAddress"), PAddress);

            Sleep(1000);

            Scroll(0, 200);

            Sleep(1000);

            SimpleClick(By.Id("submit"));

            Sleep(2000);

            try
            {
                IWait<IWebDriver> Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(1));

                Wait.Until(driver1 => elementExists(By.XPath("//p[@id='name']")));

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
                var x = Driver.FindElement(by);
                return x.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }


        [Test, Order(2)]
        public void CheckBoxTest()
        {
            Test = null;
            Test = Extent.CreateTest("CheckBox").Info("CheckBoxTesting");

            try
            {
                StartBrowser("https://demoqa.com/checkbox");

                Sleep(2000);

                ExpandArrow();

                Sleep(2000);

                SelectCheckBox();

                Sleep(2000);

                RightCollapseBtn();

                Sleep(2000);

                RightExpandBtn();

                Sleep(5000);

                Test.Log(Status.Pass, "Test Pass");
            }
            catch (Exception e)
            {
                Test.Log(Status.Fail, "Test Fail");

                throw;
            }
        }

        public void ExpandArrow()
        {
            FindElements(By.XPath("//button[@title='Toggle']"))[0].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[1].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[2].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[3].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[4].Click();
            Sleep(2000);

            FindElements(By.XPath("//button[@title='Toggle']"))[5].Click();
            Sleep(2000);
        }

        public void SelectCheckBox()
        {
            // Click on Home Folder Icon
            SimpleClick(By.XPath("//span[text()='Home']"));
        }

        public void RightExpandBtn()
        {
            // Using Class
            SimpleClick(By.ClassName("rct-option-expand-all"));

            // Using XPath
            //SimpleClick(By.XPath("//button[contains(@class,'rct-option-expand-all')]"));
        }

        public void RightCollapseBtn()
        {
            // Using Class
            SimpleClick(By.ClassName("rct-option-collapse-all"));

            // Using XPath
            //SimpleClick(By.XPath("//button[contains(@class,'rct-option-collapse-all')]"));
        }

        [TearDown]
        public void CloseChrome()
        {
            Driver.Close();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            Extent.Flush();
        }
    }
}

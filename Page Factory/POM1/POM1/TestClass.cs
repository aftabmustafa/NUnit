using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POM1.PageObjects;
using SeleniumExtras.PageObjects;

namespace POM1
{
    public class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            driver.Url = "https://demoqa.com/text-box";

            var TextBox = new TextBoxPage(driver);

            TextBox.FirstName.SendKeys("Aria");
            
            TextBox.Email.SendKeys("aria@gmail.com");
            
            TextBox.CA.SendKeys("Current Address");
            
            TextBox.PA.SendKeys("Permanent Address");

            TextBox.ClickSubmitButton();
        }

        [Test]
        public void Test2()
        {
            driver.Url = "https://demoqa.com/login";

            var Login = new LoginPage(driver);

            Login.LogIntoApplication();

            //PageFactory.InitElements(driver, Login);

            //Login.Username.SendKeys("aria");

            //Login.Password.SendKeys("@riaLabel2022");

            //Login.SubmitButton.Click();
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

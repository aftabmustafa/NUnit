using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POM1.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "userName")]
        [CacheLookup]
        private IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        private IWebElement SubmitButton { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

            PageFactory.InitElements(driver, this);
        }

        public void LogIntoApplication()
        {
            Username.SendKeys("aria");
            Password.SendKeys("@riaLabel2022");
            SubmitButton.Click();
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Base
    {
        public IWebDriver Driver;
        
        [SetUp]
        public void Initialize()
        {
            Driver = new ChromeDriver();

            Driver.Manage().Window.Maximize();

            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [Test]
        public void ExecuteTest()
        {
            Driver.FindElement(By.XPath("//a[contains(@class, 'login')]")).Click();

            Driver.FindElement(By.XPath("//input[@name='email']")).SendKeys("Aftab");

            Thread.Sleep(2000);

            Console.WriteLine("Email Id Entered");

            Actions action = new Actions(Driver);

            action.KeyDown(Keys.Tab)
                  .KeyUp(Keys.Tab)
                  .Build()
                  .Perform();

            Thread.Sleep(2000);

            Console.WriteLine("Tab Key pressed");
        }

        [TearDown]
        public void EndTest()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}

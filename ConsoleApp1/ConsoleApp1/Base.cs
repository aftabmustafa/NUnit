using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DqLib;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;

namespace ConsoleApp1
{
    class Base : SeleniumLib
    {
        [SetUp]
        public void Initialize()
        {
            StartBrowser("http://automationpractice.com/index.php");
        }

        [Test]
        public void ExecuteTest()
        {
            SimpleClick(By.XPath("//a[contains(@class, 'login')]"));
            TextInput(By.XPath("//input[@name='email']"), "aftab");

            Sleep(2000);

            Console.WriteLine("Email Id Entered");

            Actions action = new Actions(Driver);

            action.KeyDown(Keys.Tab)
                  .KeyUp(Keys.Tab)
                  .Build()
                  .Perform();

            Sleep(2000);

            Console.WriteLine("Tab Key pressed");
        }

        [TearDown]
        public void EndTest()
        {
            CloseBrowser();
        }
    }
}

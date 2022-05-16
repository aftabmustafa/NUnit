using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using ReportGeneration_2;

namespace ReportGeneration_2
{
    [TestClass]
    public abstract class TestBase
    {
        protected Browsers browser;
        protected Pages pages;


        [SetUp]
        public void StartUpTest()
        {
            browser = new Browsers();
            browser.Init();

            pages = new Pages(browser);

        }

        [TearDown]
        public void EndTest()
        {
            browser.Close();
        }
    }
}

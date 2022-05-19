using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace Framework_Copy
{
    [TestClass]
    public class ExtentReport
    {
        public static ExtentReports extent;
        
        public static ExtentTest test;

        [OneTimeSetUp]
        public void StartReport()
        {

            // To obtain the current solution path
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            string actualPath = path.Substring(0, path.LastIndexOf("bin"));

            string projectPath = new Uri(actualPath).LocalPath;


            // Append the html report file current project
            string reportPath = projectPath + "reports\\testRunReport.html";

            // Add QA System Info
            extent.AddSystemInfo("hostname", "my host name");

            extent.AddSystemInfo("Application Under Test", "nopCommerce Demo");

            // Adding Config XML
            avent.LoadConfig(projectPath + "Extent-Config.xml");

            

        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

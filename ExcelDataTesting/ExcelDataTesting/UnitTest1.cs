using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace ExcelDataTesting
{
    // 1. Put Excel File under the project solution
    [TestClass]
    public class UnitTest1
    {
        IWebDriver Driver;
        IJavaScriptExecutor Js;

        public static IEnumerable<object[]> ReadExcel()
        {
            using (ExcelPackage EPackage = new ExcelPackage(new FileInfo("DataSupply.xlsx")))
            {
                ExcelWorksheet EWS = EPackage.Workbook.Worksheets["TestData"];

                int RowCount = EWS.Dimension.End.Row;

                for (int row = 2; row <= RowCount; row++)
                {
                    yield return new object[]
                    {
                        EWS.Cells[row, 1].Value?.ToString().Trim(),
                        EWS.Cells[row, 2].Value?.ToString().Trim(),
                        EWS.Cells[row, 3].Value?.ToString().Trim(),
                        EWS.Cells[row, 4].Value?.ToString().Trim(),
                    };
                }
            }
        }

        [DynamicData(nameof(ReadExcel), DynamicDataSourceType.Method)]
        [TestMethod]
        public void ExcelData(string name, string email, string ca, string pa)
        {
            Driver = new ChromeDriver();
            Js = (IJavaScriptExecutor)Driver;
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            Driver.FindElement(By.Id("userName")).SendKeys(name);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("currentAddress")).SendKeys(ca);
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(pa);

            Js.ExecuteScript("window.scrollBy(0,250)");

            Thread.Sleep(2000);
            Driver.FindElement(By.Id("submit")).Click();
            Driver.Close();
            Driver.Quit();
        }
    }
}

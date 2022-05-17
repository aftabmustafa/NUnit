using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Configuration;

namespace ReportGeneration_2
{
    //public class Browsers
    class Browsers
    {
        private IWebDriver driver;
        private string baseURL;
        private string browser;

        public Browsers()
        {
            baseURL = ConfigurationManager.AppSettings["url"];

            browser = ConfigurationManager.AppSettings["browser"];
        }

        public void Init()
        {
            driver = new ChromeDriver();
        }

        public string Title { get { return driver.Title; } }
        public IWebDriver getDriver { get { return driver; } }

        public void GoTo(string url)
        {
            driver.Url = url;
        }

        public void Close()
        {
            driver.Quit();
        }
    }
}

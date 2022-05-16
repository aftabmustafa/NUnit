﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGeneration_2;
using SeleniumExtras.PageObjects;

namespace ReportGeneration_2
{
    class Pages
    {
        public Pages(Browsers browser)
        {
            _browser = browser;
        }

        Browsers _browser { get; }

        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), _browser.getDriver);

            PageFactory.InitElements(_browser.getDriver, page);

            return page;
        }

        public Home Home => GetPages<Home>();
        public Computers Computers => GetPages<Computers>();
    }
}

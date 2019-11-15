using OpenQA.Selenium;
using PageObjects.Components;
using System;
using System.Configuration;

namespace PageObjects
{
    public static class Helper
    {
        public static IWebDriver CreateWebDriver()
        {
            IWebDriver _driver = WebdriverFactory.GetWebdriver(ConfigurationManager.AppSettings["Browser"]);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            return _driver;
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Components
{
    public static class WebdriverFactory
    {
        public static IWebDriver GetWebdriver(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    return CreateChromeDriver();

                case "FF":
                    return CreateFireFoxDriver();

                default:
                    return CreateChromeDriver();
            }
        }

        public static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            return new ChromeDriver(options);
        }

        public static IWebDriver CreateFireFoxDriver()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            return new FirefoxDriver(service, options, TimeSpan.FromMinutes(1));
        }

    }
}

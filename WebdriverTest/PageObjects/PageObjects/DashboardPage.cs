using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageObjects.PageObjects
{
    public class DashboardPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public DashboardPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='wpbody - content']/div[3]/h1")]
        private IWebElement welcomePanel;


        public bool IsOnPage()
        {

            _wait.Until(ExpectedConditions.TitleContains("Dashboard"));            
            return _driver.PageSource.Contains("Dashboard");
        }

    }
}

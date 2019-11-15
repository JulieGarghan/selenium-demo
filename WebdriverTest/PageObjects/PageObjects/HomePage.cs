using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace PageObjects.PageObjects
{
    public class HomePage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(_driver, this); 
        }

        // Page Factory [FindsBy]
        [FindsBy(How = How.LinkText, Using = "Log in")]
        private IWebElement logInLink;

        public HomePage GoToPage()
        {
            _driver.Navigate().GoToUrl("https://s1.demo.opensourcecms.com/wordpress/");
            return this;
        }

        // Functions of page
        public LogInPage ClickLoginLink()
        {
            logInLink.Click();
            return new LogInPage(_driver);
        }

        public bool IsOnPage()
        {
            return logInLink.Displayed && logInLink.Enabled;
        }



    }
}

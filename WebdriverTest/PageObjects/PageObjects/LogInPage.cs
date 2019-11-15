using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace PageObjects.PageObjects
{
    public class LogInPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public LogInPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            PageFactory.InitElements(_driver, this);
            IsOnPage();
        }

        [FindsBy(How = How.CssSelector, Using = "#user_login")]
        private IWebElement logInText; 

        [FindsBy(How = How.Id, Using = "user_pass")]
        private IWebElement passwordText;

        [FindsBy(How = How.Name, Using = "wp-submit")]
        private IWebElement submitButton;


        public void EnterUserName(string username )
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#user_login")));
            logInText.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user_pass")));
            passwordText.SendKeys(password);
        }

        public DashboardPage ClickLogin()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("wp-submit")));
            submitButton.Click();
            return new DashboardPage(_driver);
        }

        public DashboardPage LoginFlow(string username, string password)
        {
            IsOnPage();
            EnterUserName(username);
            EnterPassword(password);
            submitButton.Click();
            return new DashboardPage(_driver);
        }

        public bool TextExistsOnPage(string textToFind)
        {
            IsOnPage();
            return _driver.PageSource.Contains(textToFind);
        }

        public bool IsOnPage()
        {
            _wait.Until(ExpectedConditions.TitleContains("Log In"));
            return logInText.Displayed && logInText.Enabled;
        }


    }
}

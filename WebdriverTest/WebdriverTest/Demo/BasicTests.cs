using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace WebdriverTest.Demo
{
    public class BasicTests
    {
        IWebDriver _driver;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("https://s1.demo.opensourcecms.com/wordpress/");
        }

        [TearDown]
        public void TearDown()
        {

        }


        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            _driver.Quit();
        }


        [Test]
        public void NavigateToHomePage()
        {
            string title = _driver.Title.ToLower();
            Assert.That(title, Does.Contain("wordpress"));
            Assert.That(_driver.PageSource, Does.Contain("Hello world!"));
        }

        [Test]
        public void NavigateToLoginPage()
        {
            _driver.FindElement(By.LinkText("Log in")).Click();
            string title = _driver.Title.ToLower();
            Assert.That(title, Does.Contain("log in"));
            Assert.That(_driver.PageSource, Does.Contain("Username or Email Address"));
        }


        [Test]
        public void NavigateToLoginPageLoginSuccess()
        {
            _driver.FindElement(By.LinkText("Log in")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.CssSelector("#user_login")).SendKeys("opensourcecms");
            _driver.FindElement(By.Id("user_pass")).SendKeys("opensourcecms");
            _driver.FindElement(By.Name("wp-submit")).Click();
            string title = _driver.Title.ToLower();
            Assert.That(title, Does.Contain("dashboard"));
            Assert.That(_driver.PageSource, Does.Not.Contain("Username or Email Address"));
        }


        [Test]
        public void NavigateToLoginPageFailedLogin()
        {
            _driver.FindElement(By.LinkText("Log in")).Click();
            _driver.FindElement(By.CssSelector("#user_login")).SendKeys("opensourcecms");
            _driver.FindElement(By.Name("wp-submit")).Click();

            bool found = _driver.FindElement(By.CssSelector("#login_error")).Displayed; 
            Assert.That(found, Is.EqualTo(true));
        }



    }
}

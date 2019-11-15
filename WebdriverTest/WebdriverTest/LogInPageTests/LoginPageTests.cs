using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects.PageObjects;
using System.Configuration;

namespace WebdriverTest.LogInPageTests
{
    public class LoginPageTests : TestBase
    {
        private IWebDriver _driver;
        private HomePage _home;
        private LogInPage _loginPage;
        private DashboardPage _dashboardPage;

        [SetUp]
        public void SetUp()
        {
            _home = GoToHomePage();
            _loginPage = _home.ClickLoginLink();
        }


        [Test]
        public void GoToLoginPage()
        {
            Assert.That(_loginPage.IsOnPage(), Is.EqualTo(true));
        }

        [Test]
        public void NoUserNameLoginError()
        {
            _loginPage.EnterPassword("opensourcecms");
            _loginPage.ClickLogin();
            bool found = _loginPage.TextExistsOnPage("The username field is empty");
            Assert.That(_loginPage.IsOnPage(), Is.EqualTo(true));
            Assert.That(found, Is.EqualTo(true));
        }

        [Test]
        public void NoPasswordLoginError()
        {
            _loginPage.EnterUserName(ConfigurationManager.AppSettings["Username"]);
            _loginPage.ClickLogin();
            bool found = _loginPage.TextExistsOnPage("The password field is empty");
            Assert.That(_loginPage.IsOnPage(), Is.EqualTo(true));
            Assert.That(found, Is.EqualTo(true));
        }


        [Test]
        public void Success_HappyPathLoginFlow()
        {
            _home = GoToHomePage();
            _loginPage = _home.ClickLoginLink();
            _dashboardPage = _loginPage.LoginFlow(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
            Assert.That(_dashboardPage.IsOnPage(), Is.EqualTo(true));
        }




    }
}

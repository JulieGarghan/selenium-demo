using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using PageObjects.PageObjects;

namespace WebdriverTest.HomePageTests
{
    public class HomePageTests
    {
        IWebDriver _driver;
        HomePage _home;
        LogInPage _loginPage;

        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            _driver = Helper.CreateWebDriver();
            _home = new HomePage(_driver);
        }

        [SetUp]
        public void SetUp()
        {
            _home.GoToPage();
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
        public void NavigateToLogInPage()
        {
            LogInPage login = _home.ClickLoginLink();
            Assert.That(_driver.Title, Does.Contain("Log In ‹ opensourcecms — WordPress"), "Title not found on page");
            Assert.That(_driver.PageSource, Does.Contain("Username or Email Address"));
        }
    }
}

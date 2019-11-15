using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects;
using PageObjects.PageObjects;

namespace WebdriverTest
{
    public class TestBase
    {
        public IWebDriver _driver;
        public HomePage _home;
        public LogInPage _loginPage;


        // Runs once - before the start of all tests
        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            // do stuff required at start of test suite e.g start up loggers for reporting
            // create driver for test run 
            _driver = Helper.CreateWebDriver();

            // Check requirements have been met or Assert.Fail()
        }


        // Runs before each test 
        [SetUp]
        public void SetUp()
        {
            // do stuff before each test e.g start individual test logger 
        }


        // Runs at the end of each test
        [TearDown]
        public void TearDown()
        {
            // do reporting stuff here e.g send results to store
        }

        // Runs once - at the end of all tests 
        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // end test suite reporting etc            
            // close browser and driver session 
            _driver.Quit();
        }

        public HomePage GoToHomePage()
        {
            HomePage _home = new HomePage(_driver);
            return _home.GoToPage();
        }
    }
}

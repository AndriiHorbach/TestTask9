using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestTask.Infrastructure.Common
{
    [Binding]
    class Hooks
    {
        private static IWebDriver _driver;

        [BeforeScenario]
        public static void InitDriver()
        {
            DriverManager.Driver = new ChromeDriver();
            _driver = DriverManager.Driver;
            _driver.Manage().Window.Maximize();
        }
        [AfterScenario]
        public static void DisposeDriver()
            => _driver.Dispose();
    }
}

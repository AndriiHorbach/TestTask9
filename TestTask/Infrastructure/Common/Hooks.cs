using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestTask.Infrastructure.Common
{
    class Hooks
    {
        private static IWebDriver _driver;

        [BeforeFeature]
        [BeforeScenario]
        public static void InitDriver()
        {
            DriverManager.Driver = new ChromeDriver();
            _driver = DriverManager.Driver;
            _driver.Manage().Window.Maximize();
        }

        [AfterFeature]
        [AfterScenario]
        public static void DisposeDriver()
            => _driver.Dispose();
    }
}

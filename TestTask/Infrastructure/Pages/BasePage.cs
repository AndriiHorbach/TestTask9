using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestTask.Infrastructure.Common;

namespace TestTask.Infrastructure.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage ()
        {
            driver = DriverManager.Driver;
            PageFactory.InitElements(driver, this);
        }

        protected string ExecuteJS(string script)
        {
            return ((IJavaScriptExecutor)DriverManager.Driver).ExecuteScript(script).ToString();
        }

        protected string GetValueByCssJS (string cssLocator)
        {
            return ExecuteJS("return $('" + cssLocator + "').val()");
        }

        public void Open ()
        {
            driver.Navigate().GoToUrl(GetPageUrl());
        }

        public abstract string GetPageUrl();

        public string GetCurrentUrl()
        {
            return driver.Url;
        }
    }
}

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TestTask.Infrastructure.Common;

namespace TestTask.Infrastructure.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage (IWebDriver driver)
        {
            this.driver = driver;
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
            DriverManager.Driver.Navigate().GoToUrl(GetPageUrl());
        }

        public abstract string GetPageUrl();
    }
}

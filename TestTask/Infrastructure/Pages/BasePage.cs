using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
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

        public WebDriverWait Wait = new WebDriverWait(DriverManager.Driver, TimeSpan.FromSeconds(10))
        {
            PollingInterval = TimeSpan.FromMilliseconds(100)
        };

        public void WaitForPageLoad()
            => Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

        public bool IsElementDisplayed (IWebElement control)
        {
            try
            {
                return control.Displayed;
            }
            catch (Exception) { return false; }
        }

        public void WaitUntilElementAvaialable(By @by)
        {
            Wait.Until(ExpectedConditions.ElementExists(@by));
            Wait.Until(ExpectedConditions.ElementIsVisible(@by));
            Wait.Until(ExpectedConditions.ElementToBeClickable(@by));
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

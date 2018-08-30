using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Infrastructure.Common;
using TestTask.Infrastructure.Controls.Elements;

namespace TestTask.Infrastructure.Pages
{
    public class BasePage
    {
        public WebDriverWait Wait = new WebDriverWait(DriverManager.Driver, TimeSpan.FromSeconds(10))
        {
            PollingInterval = TimeSpan.FromMilliseconds(100)
        };

        public void WaitForPageLoad()
            => Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

        public bool IsElementDisplayed (HtmlControl control)
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
    }
}

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestTask.Infrastructure.Pages
{
    class LoginPage : BasePage
    {
        public readonly string Url = "https://passport.i.ua/login/";

        [FindsBy(How = How.CssSelector, Using = "div.block_alert>div.content")]
        public IWebElement ErrorMessageElement;

        public override string GetPageUrl()
        {
            return Url;
        }

        public string GetErrorMessage()
        {
            return ErrorMessageElement.Text;
        }
    }
}
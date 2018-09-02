using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestTask.Infrastructure.Common;

namespace TestTask.Infrastructure.Pages
{
    class ConverterPage : BasePage
    {  
        public ConverterPage(IWebDriver driver) : base(driver) {  }

        public static readonly string Url = "https://finance.i.ua/converter/";

        [FindsBy(How = How.Id, Using = "currency_amount")]
        public IWebElement CurrencyInput;

        [FindsBy(How = How.Id, Using = "form_converter_result")]
        private IWebElement ConverterResultElement;

        [FindsBy(How = How.Id, Using = "converter_currency")]
        private IWebElement CurrencyDropdownElement;

        public SelectElement CurrencyDropdown
        {
            get { return new SelectElement(CurrencyDropdownElement); }
        }

        public string GetValueForCurrency(string currency, string type)
        {
            return ((IJavaScriptExecutor)DriverManager.Driver)
                .ExecuteScript("return $('p#" + currency + ">#currency_"+ type + "').val()")
                .ToString().Replace(" ", "");
        }

        public string GetCurrencyExchange(string currency)
        {
            return GetValueByCssJS("p#" + currency + ">#currency_exchange").Replace(" ", "");
        }

        public string GetCurrencyRate(string currency)
        {
            return GetValueByCssJS("p#" + currency + ">#currency_rate").Replace(" ", "");
        }

        public void SelectCurrencyFromDropdown(string currency)
        {
            CurrencyDropdown.SelectByText(currency);
        }

        public void SetAmountOfCurrency(string amount)
        {
            CurrencyInput.SendKeys(amount);
        }

        public override string GetPageUrl()
        {
            return Url;
        }
    }
}

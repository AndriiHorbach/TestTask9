using OpenQA.Selenium;
using System;
using System.Linq;
using SeleniumExtras.PageObjects;
using TestTask.Infrastructure.Data;

namespace TestTask.Infrastructure.Pages
{
    class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        public  readonly string Url = "https://finance.i.ua/";

        [FindsBy(How = How.CssSelector, Using = "div.widget-currency_bank>div>table")]
        public IWebElement DataTable;

        public AvegareCurrenceRateRow GetAverageCurrencyCells(string currency)
        {
            var currencyCells = DataTable.FindElements(By.XPath(".//tbody/tr/th[contains(text(), '"+currency+ "')]/../td")).ToList();
            var avegareCurrenceRateRow = new AvegareCurrenceRateRow();
            avegareCurrenceRateRow.Buy = Decimal.Parse(currencyCells[0].Text.Remove((currencyCells[0].Text.IndexOf('\r'))));
            avegareCurrenceRateRow.Sell = Decimal.Parse(currencyCells[1].Text.Remove((currencyCells[1].Text.IndexOf('\r'))));
            avegareCurrenceRateRow.NBU = Decimal.Parse(currencyCells[2].Text.Remove((currencyCells[2].Text.IndexOf('\r'))));
            avegareCurrenceRateRow.Name = currency;
            return avegareCurrenceRateRow;
        }

        public override string GetPageUrl()
        {
            return Url;
        }
    }
}

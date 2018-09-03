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

        public readonly string Url = "https://finance.i.ua/";

        [FindsBy(How = How.CssSelector, Using = "div.widget-currency_bank>div>table")]
        public IWebElement CurrencyRatesInBanksDataTable;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Вход')]")]
        public IWebElement LoginLink;

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement LoginField;

        [FindsBy(How = How.Name, Using = "pass")]
        public IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        public IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = "div.widget-fuel_average>div>table")]
        public IWebElement FuelCostDataTable;

        public AvegareCurrenceRateRow GetAverageCurrencyCells(string currency)
        {
            var currencyCells = CurrencyRatesInBanksDataTable.FindElements(By.XPath(".//tbody/tr/th[contains(text(), '" + currency + "')]/../td")).ToList();
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

        public void LoginAsUser(string userLogin, string userPassword)
        {
            LoginLink.Click();
            LoginField.SendKeys(userLogin);
            PasswordField.SendKeys(userPassword);
            SubmitButton.Submit();
        }

        public AverageFuelPricesRow GetAverageFuelPriceCells()
        {
            var fuelCells = FuelCostDataTable.FindElements(By.XPath(".//tbody//td")).ToList();
            var averareFuelPricesRow = new AverageFuelPricesRow();
            averareFuelPricesRow.A92 = Decimal.Parse(fuelCells[0].Text);
            averareFuelPricesRow.A95 = Decimal.Parse(fuelCells[1].Text);
            averareFuelPricesRow.Diesel = Decimal.Parse(fuelCells[2].Text);
            return averareFuelPricesRow;
        }
    }
}

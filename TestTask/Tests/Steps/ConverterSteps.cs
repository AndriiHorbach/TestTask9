using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestTask.Infrastructure.Pages;

namespace TestTask.Tests.Steps
{
    [Binding]
    class ConverterSteps
    {
        private readonly ConverterPage _ConverterPage = new ConverterPage();

        [Given("Converter page is opened")]
        public void GivenIAmOnTheHomePage()
            => _ConverterPage.Open();

        [When("I convert (.*) of (.*) currency")]
        public void WhenIConvertOfUsd(string amount, string currency)
        {
            _ConverterPage.CurrencyInput.SendKeys(amount);
            _ConverterPage.SelectCurrencyFromDropdown(currency);
        }

        [Then("I see correct converted amount in (.*) for (.*) of selected currency")]
        public void ThenISeeCorrectConvertedAmount(string convertedCurrency, string amount)
        {
            decimal actualAmount = _ConverterPage.GetCurrencyExchange(convertedCurrency);
            decimal exchangeRate = _ConverterPage.GetCurrencyRate(convertedCurrency);
            decimal expectedAmount = Decimal.Multiply(Decimal.Parse(amount), exchangeRate);
            Assert.AreEqual(expectedAmount, actualAmount, "expected and actual amounts are not equal");
        }
    }
}

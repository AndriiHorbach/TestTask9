using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestTask.Infrastructure.Common;
using TestTask.Infrastructure.Pages;

namespace TestTask.Tests.Steps
{
    [Binding]
    class ConverterSteps
    {
        private readonly ConverterPage _ConverterPage = new ConverterPage(DriverManager.Driver);

        [Given(@"Converter page is opened")]
        public void GivenIAmOnTheHomePage()
            => _ConverterPage.Open();

        [When(@"I convert (.*) of (.*) currency")]
        public void WhenIConvertOfUsd(string amount, string currency)
        {
            _ConverterPage.CurrencyInput.SendKeys(amount);
            _ConverterPage.SelectCurrencyFromDropdown(currency);
        }

        [Then(@"I see correct converted amount in (.*)")]
        public void ThenISeeCorrectConvertedAmount(string convertedCurrency)
        {

            var convertedAmount = _ConverterPage.GetCurrencyExchange(convertedCurrency);
            var actualAmount = Decimal.Parse(convertedAmount);
            var exchangeRate = _ConverterPage.GetCurrencyRate(convertedCurrency);
            var expectedAmount = Decimal.Multiply(1000,Decimal.Parse(exchangeRate));
            Assert.AreEqual(expectedAmount, actualAmount, "expcted and actual amounts are not equal");
        }
    }
}

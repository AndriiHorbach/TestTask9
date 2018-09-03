using NUnit.Framework;
using TechTalk.SpecFlow;
using TestTask.Infrastructure.Common;
using TestTask.Infrastructure.Pages;

namespace TestTask.Tests.Steps
{
    [Binding]
    class MainPageSteps
    {
        private readonly MainPage _MainPage = new MainPage(DriverManager.Driver);

        [Given("Main page is opened")]
        public void GivenIAmOnTheMainPage()
            => _MainPage.Open();

        [Then("For (.*) currency sale rate is greater than buy rate")]
        public void ThenForCurrnecySaleRateIsGreaterThanBuyRate(string currency)
        {
            var currencyCells = _MainPage.GetAverageCurrencyCells(currency);
            var difference = currencyCells.Sell - currencyCells.Buy;
            Assert.IsTrue(difference > 0, "Buy rate is greater than sale rate");
        }
    }
}

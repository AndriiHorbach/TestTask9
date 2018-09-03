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

        [Then("(.*) currency sale rate is greater than buy rate")]
        public void ThenForCurrnecySaleRateIsGreaterThanBuyRate(string currency)
        {
            var currencyCells = _MainPage.GetAverageCurrencyCells(currency);
            var difference = currencyCells.Sell - currencyCells.Buy;
            Assert.IsTrue(difference > 0, "Buy rate is greater than sale rate");
        }

        [Then(@"average price for A-92 is lower that for A-95")]
        public void ThenAveragePriceForAIsLowerThatForA()
        {
            var fuelCells = _MainPage.GetAverageFuelPriceCells();
            var difference = fuelCells.A92 - fuelCells.A95;
            Assert.IsTrue(difference <= 0, "Avergare price for 92 fuel is greater than average price for 95 fuel");
        }
    }
}

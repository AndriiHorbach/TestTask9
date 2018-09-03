using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestTask.Infrastructure.Data;
using TestTask.Infrastructure.Pages;

namespace TestTask.Tests.Steps
{
    [Binding]
    class LoginSteps
    {
        private readonly MainPage _MainPage = new MainPage();
        private readonly LoginPage LoginPage = new LoginPage();

        [When("I login as unregistered user")]
        public void WhenILoginAsUnregisteredUser(Table credentials)
        {
            var userData = credentials.CreateInstance<UserData>();
            _MainPage.LoginAsUser(userData.Login, userData.Password);
        }

        [Then("And see error message (.*) on the login page")]
        public void ThenAndSeeErrorMessageOnTheLoginPage(string expectedErrorMessage)
        {
            string actualUrl = LoginPage.GetCurrentUrl();
            string expectedUrl = LoginPage.Url;
            string actualErrorMessage = LoginPage.GetErrorMessage();
            Assert.AreEqual(expectedUrl, actualUrl, "URLs dont match");
            Assert.AreEqual(expectedErrorMessage, actualErrorMessage, "Wrong error message is displayed");
        }
    }
}
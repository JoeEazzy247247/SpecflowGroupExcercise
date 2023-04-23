using OpenQA.Selenium;
using RestSharp;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Microsoft.Playwright;
using BoDi;
using SpecflowGroupExcercise.Drivers;

namespace SpecflowGroupExcercise.StepDefinitions
{
    [Binding]
    public class LoginApiStepDefinitions
    {
        string user = "Jo2" + new Random().Next(1, 999);
        string passWord = "Password001!";
        private IPage _page;
        private ApiHelper _apiHelper;
        public LoginApiStepDefinitions(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
            _apiHelper = objectContainer.Resolve<ApiHelper>();
        }

        [Given(@"I create a new user")]
        public async Task GivenICreateANewUser()
        {
            //await _apiHelper.SingleApiCall("Account/v1/User", user, passWord);
            var payload = new
            {
                userName = user,
                password = passWord
            };
            await _apiHelper.SingleApiCall("Account/v1/User", payload);
        }

        [When(@"I navigate to login page")]
        public async Task WhenINavigateToLoginPage()
        {
            await _page.GetByText("Book Store Application").ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
        }

        [When(@"I enter the user name and password")]
        public async Task WhenIEnterTheUserNameAndPassword()
        {
            await _page.Locator("#userName").FillAsync(user);
            await _page.Locator("#password").FillAsync(passWord);
        }

        [Then(@"user name and password is entered")]
        public async Task ThenUserNameAndPasswordIsEntered()
        {
            await _page.GetByPlaceholder("UserName").WaitForAsync();
            await _page.GetByPlaceholder("Password").WaitForAsync();
            var username = await _page.GetByPlaceholder("UserName").InputValueAsync();
            var password = await _page.GetByPlaceholder("Password").InputValueAsync();
            Assert.AreEqual(user, username);
            Assert.AreEqual(passWord, password);
        }

        [Then(@"I finish my test")]
        public async Task ThenIFinishMyTest()
        {
            await Task.Delay(5000);
        }
    }

    public record PostRequestModelNewUser2(string userName, string password) { }
}

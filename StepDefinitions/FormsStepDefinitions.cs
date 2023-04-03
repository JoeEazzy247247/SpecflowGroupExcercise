using BoDi;
using Microsoft.Playwright;
using SpecflowGroupExcercise.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowGroupExcercise.StepDefinitions
{
    [Binding]
    public class FormsStepDefinitions
    {
        private PracticeFormPage _practiceFormPage;
        private IPage _page;
        public FormsStepDefinitions(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
            _practiceFormPage = objectContainer.Resolve<PracticeFormPage>();
        }

        [When(@"I enter the following details")]
        public async Task WhenIEnterTheFollowingDetails(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();

            await _practiceFormPage.EnterFNameLNameEmail(table.Header.FirstOrDefault(), table.Header.ElementAt(1), table.Header.ElementAt(2), string.Format(enterDetails.firstName, DateTime.Now.ToString("HHmmssfff")), string.Format(enterDetails.lastName, DateTime.Now.ToString("HHmmssfff")), string.Format(enterDetails.userEmail, DateTime.Now.ToString("HHmmssfff")));
        }

        [When(@"I choose gender (.*)")]
        public async Task WhenIChooseGenderOption(string genderOption) => await _practiceFormPage.ClickGender();

        [When(@"I enter mobile number ([^']*)")]
        public async Task WhenIEnterMobileNumber(string MobileOption) => await _practiceFormPage.EnterMobileNumber(MobileOption); 

        [When(@"I enter date of birth ([^']*)")]
        public async Task WhenIEnterDateOfBirthOct(string DobOption)
        {
            await _practiceFormPage.EnterDOBOpt();
        }

        [When(@"I choose hobbies")]
        public async void WhenIChooseHobbies()
        {
            
        }

        [When(@"I select picture")]
        public async Task WhenISelectPicture()
        {
            
        }

        [When(@"I eneter current address")]
        public async Task WhenIEneterCurrentAddress()
        {
            
        }

        [When(@"I select state")]
        public void WhenISelectState()
        {
            
        }

        [When(@"I select city")]
        public void WhenISelectCity()
        {
            
        }

        [Then(@"I click on submit btn")]
        public void ThenIClickOnSubmitBtn()
        {
            
        }
    }
}
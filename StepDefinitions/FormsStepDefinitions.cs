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

        [When(@"I enter date of birth '([^']*)','([^']*)'")]
        public async Task WhenIEnterDateOfBirthOct(string day, string DobOption)
        {
            await _practiceFormPage.EnterDOBOpt(day, DobOption);
        }

        [When(@"I choose hobbies")]
        public async Task WhenIChooseHobbies() => await _practiceFormPage.SelectHobbies();

        [When(@"I select picture '([^']*)'")]
        public async Task WhenISelectPicture() => await _practiceFormPage.EnterPitcure();

        [When(@"I eneter current ([^']*)")]
        public async Task WhenIEneterCurrentAddress(string AddresAlias) => await _practiceFormPage.EnterCAddress(AddresAlias);

        [When(@"I select state")]
        public async Task WhenISelectState() => await _practiceFormPage.EnterState();


        [When(@"I select city")]
        public async Task WhenISelectCity() => await _practiceFormPage.EnterCity();

        [Then(@"I click on submit btn")]
        public async Task ThenIClickOnSubmitBtn() => await _practiceFormPage.ClickSubmitBtn();
    }
}
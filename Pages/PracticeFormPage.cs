using BoDi;
using Microsoft.Playwright;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowGroupExcercise.Pages
{
    public class PracticeFormPage
    {
        private IPage _page;
        public PracticeFormPage(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
        }

        ILocator FNameField(string FNameOption) => _page.Locator($"//input[@id='{FNameOption}']");

        ILocator LNameField(string LNameOption) => _page.Locator($"//input[@id='{LNameOption}']");

        ILocator UserEmailField(string EmailOption) => _page.Locator($"//input[@id='{EmailOption}']");

        ILocator ChooseGender => _page.Locator("(//*[contains(@for, 'gender-radio')])[1]");
        //ILocator ChooseGender(string GenderOption) => _page.GetByText($"{GenderOption}");

        ILocator UserMobileField => _page.Locator("#userNumber");

        ILocator DOBInputField => _page.Locator("//*[@id='dateOfBirthInput']");

        ILocator EnterDOB()=> _page.Locator("//div[@aria-label='Choose Monday, April 3rd, 2023']");
        //div[@aria-label='Choose Monday, April 3rd, 2023']

        ILocator submit => _page.Locator("#submit");

        //ILocator Output => _page.Locator("#output");


        
        public async Task EnterFNameLNameEmail(string FName_Option, string LName_Option, string Email_Option, string FirstName,
            string LastName, string Email)
        {
            await FNameField(FName_Option).First.FillAsync(FirstName);
            await LNameField(LName_Option).FillAsync(LastName);
            await UserEmailField(Email_Option).FillAsync(Email);
        }
        public async Task ClickGender() => await ChooseGender.ClickAsync();
        public async Task EnterMobileNumber(string Mobile) => await UserMobileField.FillAsync(Mobile);
        public async Task EnterDOBOpt()
        {
            //await DOBInputField.ClearAsync();
            await EnterDOB().ClickAsync();
        }
     
        //await submit.ClickAsync();
        //public async Task<bool> IsOutPutDisplayed() => await Output.IsVisibleAsync();
    }
}
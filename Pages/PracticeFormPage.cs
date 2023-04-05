using BoDi;
using Microsoft.Playwright;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using SpecflowGroupExcercise.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        ILocator UserMobileField => _page.Locator("#userNumber");
        ILocator DOBInputField => _page.Locator("//*[@id='dateOfBirthInput']");
        ILocator EnterDOB(string day, string date) => _page.GetByRole(AriaRole.Option, new()
        { Name = $"Choose {day}, {date}" });
        ILocator ChooseHobbies => _page.GetByText("Sports");
        ILocator EnterCurrentAdd => _page.GetByPlaceholder("Current Address");
        ILocator UploadPicture => _page.Locator("#uploadPicture");
        ILocator ClickStateField => _page.Locator("//*[@id='state']");
        ILocator SelectState => _page.GetByText("NCR", new() { Exact = true });
        ILocator ClickCityField => _page.Locator("//*[@id='city']");
        ILocator SelectCity => _page.GetByText("Delhi", new() { Exact = true });
        ILocator submit => _page.Locator("#submit");
        ILocator CloseModalBtn => _page.GetByRole(AriaRole.Button, new() { Name = "Close" });




        public async Task EnterFNameLNameEmail(string FName_Option, string LName_Option, string Email_Option, string FirstName,
            string LastName, string Email)
        {
            await FNameField(FName_Option).First.FillAsync(FirstName);

            await LNameField(LName_Option).FillAsync(LastName);

            await UserEmailField(Email_Option).FillAsync(Email);
        }
        public async Task ClickGender() => await ChooseGender.ClickAsync();
        public async Task EnterMobileNumber(string Mobile) => await UserMobileField.FillAsync(Mobile);
        public async Task EnterDOBOpt(string day, string date)
        {
            await DOBInputField.ClickAsync();

            await EnterDOB(day, date).ClickAsync();
        }
        public async Task SelectHobbies() => await ChooseHobbies.ClickAsync();
        public async Task EnterCAddress(string CAddress) => await EnterCurrentAdd.FillAsync(CAddress);
        public async Task EnterPitcure() => await UploadPicture.SetInputFilesAsync(ConfigurationFactory.FileUpload());
        public async Task EnterState()
        {
            await ClickStateField.ClickAsync();

            await SelectState.ClickAsync();
        }
        public async Task EnterCity()
        {
            await ClickCityField.ClickAsync();

            await SelectCity.ClickAsync();
        }
        public async Task ClickSubmitBtn() => await submit.ClickAsync();
        public async Task ClickCloseBtn() => await CloseModalBtn.ClickAsync();
    }
}
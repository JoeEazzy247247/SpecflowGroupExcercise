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
        //Action action = new Action(_page);
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

        ILocator EnterDOB(string day, string date) => _page.GetByRole(AriaRole.Option, new() { Name = $"Choose {day}, {date}" });

        ILocator ChooseHobbies => _page.GetByText("Sports");
        ILocator EnterCurrentAdd => _page.GetByPlaceholder("Current Address");
        ILocator UploadPicture => _page.GetByLabel("Select picture");
        //ILocator SelectState => _page.Locator("//*[@id='state']");
        ILocator SelectState => _page.GetByText("NCR", new() { Exact = true });
        //ILocator SelectCity => _page.Locator("//*[@id='city']");
        ILocator SelectCity => _page.Locator("#city svg");



    //    await page.GetByText("NCR", new () { Exact = true }).ClickAsync();

    //await page.Locator("#city svg").ClickAsync();


    //await page.GetByLabel("Select picture").SetInputFilesAsync(new[] { "VATImage.png" });
    //await page.GetByLabel("Select picture").ClickAsync();
    //await page.GetByPlaceholder("Current Address").ClickAsync();
    //await page.GetByText("Sports").ClickAsync();

    //*[@class='custom-control-label'][.='Sports']
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
        public async Task EnterDOBOpt(string day, string date)
        {
            //await _page.PauseAsync();
            await DOBInputField.ClickAsync();
            await EnterDOB(day, date).ClickAsync();
        }
        public async Task SelectHobbies() => await ChooseHobbies.ClickAsync();
        public async Task EnterCAddress(string CAddress) => await EnterCurrentAdd.FillAsync(CAddress);
        public async Task EnterPitcure() => await UploadPicture.SetInputFilesAsync(new[] { "VATImage.png" });
        //FillAsync(pUpload);

        public async Task EnterState() => await SelectState.ClickAsync();   
        public async Task EnterCity() => await SelectCity.ClickAsync();   
        public async Task ClickSubmitBtn() => await submit.ClickAsync();   


        //await ClickHobbies().ChooseHobbies(hobbiesOption).ClickAsync();
        // await _page.GetByText("Sports").ClickAsync();

        //await submit.ClickAsync();
        //public async Task<bool> IsOutPutDisplayed() => await Output.IsVisibleAsync();
    }
}
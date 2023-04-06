using BoDi;
using Microsoft.Playwright;

namespace SpecflowGroupExcercise.Pages
{
    public class TextBoxPage
    {
        private IPage _page;
        public TextBoxPage(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
        }

        ILocator inputFields(string option) => 
            _page.Locator($"//label[@class='form-label'][.='{option}']//following::div/input");

        ILocator AddressFields(string option) =>
            _page.Locator($"//label[@class='form-label'][.='{option}']//following::div/textarea");

        ILocator submit => _page.Locator("#submit");

        ILocator Output => _page.Locator("#output");


        public async Task CompleteForm(string option1, string option2, string Addressoption1, string Addressoption2,
            string FullName, string UserEmail, string currentaddress, string permAddress)
        {
            await inputFields(option1).First.FillAsync(FullName);
            await inputFields(option2).FillAsync(UserEmail);
            await AddressFields(Addressoption1).First.FillAsync(currentaddress);
            await AddressFields(Addressoption1).Last.FillAsync(permAddress);
            await submit.ClickAsync();
        }

        public async Task<bool> IsOutPutDisplayed() => await Output.IsVisibleAsync();
    }
}
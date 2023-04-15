using BoDi;
using Microsoft.Playwright;

namespace SpecflowGroupExcercise.Pages
{
    public class AlertsPage
    {
        private IPage _page;
        public AlertsPage(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
        }

        ILocator ClickOption(string option) => _page.GetByRole(AriaRole.Listitem).Filter(new() { HasText = $"{option}" });
        ILocator AlertBtn => _page.Locator("#alertButton");
        ILocator Alert(string alertsMenu) => _page.Locator($"//li[@id='item-1'][.='Alerts']");
        ILocator alertText(string alertWindows) => _page.Locator("//div[@class='main-header']");

        public async Task ClickAlerts(string option) => await ClickOption(option).ClickAsync();

        public async Task ClickAlertBtn()
        {
            _page.Dialog += (_, dialog) => dialog.AcceptAsync();
            _page.Dialog += (_, dialog) => Console.WriteLine(dialog.Message);
            await AlertBtn.ClickAsync();
        }

        public async Task<bool> IsAlertTextVisible(string alertWindows) => await alertText(alertWindows).IsVisibleAsync();
    }
}
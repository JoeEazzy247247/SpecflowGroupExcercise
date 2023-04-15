using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using Microsoft.Playwright;
using SpecflowGroupExcercise.Utilities;

namespace SpecflowGroupExcercise.Pages
{
    public class AlertsPage
    {
        private IPage _page;
        public AlertsPage(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
        }

        ILocator alertText(string alertWindows) => _page.Locator("//div[@class='main-header']");
        public async Task<bool> IsAlertTextVisible(string alertWindows) => await alertText(alertWindows).IsVisibleAsync();
        ILocator Alert(string alertsMenu) => _page.Locator($"//li[@id='item-1'][.='Alerts']");
        public async Task<bool> IsAlertsVisible(string alertsMenu) => await Alert(alertsMenu).IsVisibleAsync();
        public async Task ClickAlertsMenu(string alerts) => await Alert(alerts).ClickElement();

        ILocator AlertButton0(string alert0) => _page.Locator("//button[@id='alertButton']");
        public async Task ClickAlert0(string alert0) => await Alert(alert0).ClickElement();
        
        ILocator AlertButton1(string alert1) => _page.Locator("//button[@id='timerAlertButton']");
        ILocator AlertButton2(string alert2) => _page.Locator("//button[@id='confirmButton']");
        ILocator AlertButton3(string alert3) => _page.Locator("//button[@id='promtButton']");
        //public async Task ClickAlertBtn0(string alert0) => await AlertButton0(alert0).ClickElement();

        //public async Task AlertBtnClick(string alert0, string alert1, string alert2, string alert3)
        //{
        //    await AlertButton0(alert0).ClickElement;
        //    await AlertButton1(alert1);
        //    await AlertButton2(alert2);
        //    await AlertButton3(alert3);
            //await inputFields(option2).FillAsync(UserEmail);
            //await AddressFields(Addressoption1).First.FillAsync(currentaddress);
            //await AddressFields(Addressoption1).Last.FillAsync(permAddress);
            //await submit.ClickAsync();
        }
}
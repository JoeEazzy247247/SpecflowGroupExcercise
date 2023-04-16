using BoDi;
using Microsoft.Playwright;
using SpecflowGroupExcercise.Configurations;
using SpecflowGroupExcercise.Drivers;
using TechTalk.SpecFlow;

namespace SpecflowGroupExcercise.Hooks
{
    [Binding]
    public sealed class Basehooks : DriverContext
    {
        public Basehooks(IObjectContainer objectContainer)
        {
            _container = objectContainer;
        }

        [BeforeScenario]
        public async Task BeforeScenarioWithTag()
        {
            _playwright = await Playwright.CreateAsync();

            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chrome",
                SlowMo = 10
            };
            _browser = await _playwright.Chromium.LaunchAsync(launchOptions);

            var pageOptions = new BrowserNewPageOptions
            {
                ViewportSize = new ViewportSize { Height = 1080, Width = 1920 }
            };
            _page = await _browser.NewPageAsync(pageOptions);

            var remoteAddress = ConfigurationFactory.GetRemoteAddress;
            await _page.GotoAsync(remoteAddress);

            _container.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await _browser.CloseAsync();
        }
    }
}
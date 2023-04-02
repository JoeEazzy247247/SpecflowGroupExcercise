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
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chrome",
                SlowMo = 10
            });
            _page = await _browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = new ViewportSize { Height = 1080, Width = 1920 }
            });
            await _page.GotoAsync(ConfigurationFactory.GetRemoteAddress);
            _container.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            await _browser.CloseAsync();
        }
    }
}
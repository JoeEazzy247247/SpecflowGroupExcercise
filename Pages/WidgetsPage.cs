using BoDi;
using Microsoft.Playwright;

namespace SpecflowGroupExcercise.Pages
{
    public class WidgetsPage
    {
        private IPage _page;
        public WidgetsPage(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
        }

        ILocator Accordian(string option) => _page.GetByText($"{option}");

        public async Task ClickOption(string option) => await Accordian(option).ClickAsync();
        public async Task<bool> IsElementVisible(string text) => await Accordian(text).IsVisibleAsync(); 
    }
}

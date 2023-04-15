using BoDi;
using Microsoft.Playwright;
using SpecflowGroupExcercise.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowGroupExcercise.Pages
{
    public class HomePage
    {
        private IPage _page;
        public HomePage(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
        }

        ILocator elements(string option) => _page.GetByText($"{option}");

        public async Task ClickOption(string option) => await _page.ClickByTextAsync(option);
    }
}

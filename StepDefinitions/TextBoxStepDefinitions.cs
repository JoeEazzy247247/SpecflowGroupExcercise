using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowGroupExcercise.Pages;

namespace SpecflowGroupExcercise.StepDefinitions
{
    [Binding]
    public class TextBoxStepDefinitions
    {
        private TextBoxPage _tpage;
        private HomePage _hpage;
        private IPage _page;
        public TextBoxStepDefinitions(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
            _hpage = objectContainer.Resolve<HomePage>();
            _tpage = objectContainer.Resolve<TextBoxPage>();
        }

        [Scope(Tag = "ElementTest")]
        [Then(@"I am on (.*) page")]
        public async Task ThenIAmOnTextBoxPage(string urlSlug)
        {
            Assert.True(await Task.FromResult(_page.Url.Contains(urlSlug.ToLower())));
        }

        [Scope(Tag = "ElementTest")]
        [When(@"I complete the following form")]
        public async Task WhenICompleteTheFollowingForm()
        {
            await _tpage.CompleteForm("Full Name", "Email", "Current Address", "Permanent Address", "Joe", "abc@abc.com", "My c address", "My p address");
        }

        [Scope(Tag = "ElementTest")]
        [Then(@"form is completed")]
        public async Task ThenFormIsCompleted()
        {
            Assert.True(await _tpage.IsOutPutDisplayed());
        }

        [Scope(Tag = "ElementTest")]
        [When(@"I click (.*) menu")]
        public async Task WhenIClickTextBoxMenu(string elementAlias)
        {
            await _hpage.ClickOption(elementAlias);
        }
    }
}

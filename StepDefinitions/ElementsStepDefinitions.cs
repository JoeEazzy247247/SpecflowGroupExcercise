using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowGroupExcercise.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecflowGroupExcercise.StepDefinitions
{
    [Binding]
    public class ElementsStepDefinitions
    {
        private HomePage _hpage;
        private TextBoxPage _tpage;
        private IPage _page;
        public ElementsStepDefinitions(IObjectContainer objectContainer)
        {
            _hpage = objectContainer.Resolve<HomePage>();
            _page = objectContainer.Resolve<IPage>();
            _tpage = objectContainer.Resolve<TextBoxPage>();
        }

        [Given(@"I am on (.*) site")]
        public async Task GivenIAmOnDemoqaSite(string urlSlug)
        {
            Assert.True(await Task.FromResult(_page.Url.Contains(urlSlug)));
        }

        [When(@"I click (.*)")]
        public async Task WhenIClickElements(string elementAlias)
        {
            await _hpage.ClickOption(elementAlias);
        }

        [Scope(Tag = "FormTest")]
        [When(@"I click (.*) menu")]
        public async Task WhenIClickElementsFormMenu(string elementAlias)
        {
            await _hpage.ClickOption(elementAlias);
        }

        [Then(@"I am on (.*) page")]
        public async Task ThenIAmOnElementsPage(string urlSlug)
        {
            Assert.True(await Task.FromResult(_page.Url.Contains(urlSlug.ToLower())));
        }
    }
}
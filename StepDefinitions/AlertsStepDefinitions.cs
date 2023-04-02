using System;
using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecflowGroupExcercise.Pages;
using TechTalk.SpecFlow;

namespace SpecflowGroupExcercise.StepDefinitions
{
    [Binding]
    public class AlertsStepDefinitions
    {

        private HomePage _hpage;
        private AlertsPage _apage;
        private IPage _page;
        public AlertsStepDefinitions(IObjectContainer objectContainer)
        {
            _hpage = objectContainer.Resolve<HomePage>();
            _page = objectContainer.Resolve<IPage>();
            _apage = objectContainer.Resolve<AlertsPage>();
        }

        [Given(@"I land on (.*) site")]
        public async Task GivenILandOnDemoqaSite(string urlSlug)
        {
            Assert.True(await Task.FromResult(_page.Url.Contains(urlSlug)));
        }

        [When(@"I select (.*) element")]
        public async Task WhenISelectAlertsFrameWindowsElement(string elementAlias)
        {
            await _apage.ClickOption(elementAlias);
        }

        [Then(@"I land on (.*) page")]
        public async Task ThenILandOnAlertsFrameWindowsPage(string urlSlug)
        {
            
        }

        [When(@"I select (.*) element")]
        public async Task WhenISelectAlertsElement(string elementAlias)
        {
            
        }

        [Then(@"I land on (.*) page")]
        public async Task ThenILandOnAlertsPage(string urlSlug)
        {
            
        }
    }
}

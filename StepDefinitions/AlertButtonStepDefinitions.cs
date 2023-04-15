using System;
using BoDi;
using Microsoft.Playwright;
using SpecflowGroupExcercise.Pages;
using TechTalk.SpecFlow;

namespace SpecflowGroupExcercise.StepDefinitions
{
    [Binding]
    public class AlertButtonStepDefinitions
    {
        private AlertsPage _apage;
        private IPage _page;
        public AlertButtonStepDefinitions(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
            _apage = objectContainer.Resolve<AlertsPage>();
        }

        [Then(@"I confirm the first Alert button")]
        public async Task WhenIConfirmTheFirstAlertButton()
        {
            await _apage.ClickAlertBtn();
        }
    }
}

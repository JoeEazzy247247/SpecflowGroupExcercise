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
        private HomePage _hpage;
        private IPage _page;
        public AlertButtonStepDefinitions(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
            _hpage = objectContainer.Resolve<HomePage>();
            _apage = objectContainer.Resolve<AlertsPage>();
        }

        [When(@"I confirm all the Alerts")]
        public async Task WhenIConfirmAllTheAlerts(string alert0)
        {
            
        }

        [Then(@"Alert test is complete")]
        public async Task ThenAlertTestIsComplete()
        {
            
        }
    }
}

Feature: Alerts

@AlertsTest
Scenario: Summon all Alerts
	Given I land on demoqa site
	When I select Alerts, Frame & Windows element
	Then I land on Alerts, Frame & Windows page
	When I click Alerts menu
	Then I land on Alerts webpage
	And I confirm the first Alert button
﻿Feature: Alerts


@AlertsTest
Scenario: Summon all different Alerts
	Given I land on demoqa site
	When I select Alerts, Frame & Windows element
	Then I land on Alerts, Frame & Windows page
	When I select Alerts element
	Then I land on Alerts page
Feature: Elements


@ElementTest
Scenario: Fill Element page form
	Given I am on demoqa site
	When I click Elements
	Then I am on Elements page
	When I click Text Box menu
	Then I am on Text-Box page
	When I complete the following form
	Then form is completed
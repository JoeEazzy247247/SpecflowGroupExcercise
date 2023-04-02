Feature: Widgets


@WidgetsTest
Scenario: Fill Element page form
	Given I am on demoqa site
	When I click Widgets
	Then I am on Widgets page
	When I click Accordian menu
	Then I am on Accordian page
	Then What is Lorem Ipsum? is displayed


Feature: Forms


@FormTest
Scenario: Verify user is able to navigate to forms page on demoqa and fill practice form successfully.
	Given I am on demoqa site
	When I click Forms
	Then I am on Forms page
	When I click Practice Form menu
	Then I am on automation-practice-form page
	When I enter the following details
		| firstName   | lastName  | userEmail              |
		| TestUser{0} | QaUser{0} | authoTest{0}@abc.co.uk |
	And I choose gender Male
	And I enter mobile number 07799440954
	And I enter date of birth 03 Apr 2023
	#And I enter subject
	And I choose hobbies
	And I select picture
	And I eneter current address
	And I select state
	And I select city
	Then I click on submit btn
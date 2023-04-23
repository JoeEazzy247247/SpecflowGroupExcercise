Feature: LoginApi
Background: 
	Given I create a new user


@tag1
Scenario: Web api test
	When I navigate to login page
	And I enter the user name and password
	Then user name and password is entered
	And I finish my test

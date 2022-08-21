Feature: SignIn

When a user enters details that do match a corresponding email address and password combination, they are taken to the accounts page

@tag1
Scenario: Signing in with a valid email and password combination
	Given I navigate to the front page
	And I click on Sign in
	When I enter an existing email address and password
	Then I should successfully reach the accounts page

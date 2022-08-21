Feature: Sign in failure

When a user enters details that do not match a corresponding email address and password combination, an error message is given

@tag1
Scenario: Signing in with an invalid email and password combination
	Given I navigate to the front page
	And I click on Sign in
	When I enter a valid email address and invalid password
	Then I should recieve an error message
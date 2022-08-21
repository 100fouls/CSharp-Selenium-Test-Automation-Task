Feature: Registration 

When a user enters details that are correctly formatted and required for registration, they are able to create an account and are taken to the accounts page

@tag1
Scenario: Registering an account
	Given I navigate to the front page
	And I click on Sign in
	And I enter a valid email address format to create an account
	And I enter correctly formatted details in all of the required fields
	When click Register
	Then I should successfuly create a new account
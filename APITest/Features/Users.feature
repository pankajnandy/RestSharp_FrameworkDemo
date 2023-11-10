Feature: Users

A short summary of the feature

Scenario: Create newUser
	Given I Input name "Pankaj"
	And I Input job "QA"
	When I post request to create user
	Then Validate newUser is created

Scenario: Get singleUser
	Given From a list of valid created Users
	When I try to get details of Single User "2"
	Then  Validate I get a success status Code
	And Validate the User fields

Scenario: Put singleUser
	Given From user Path User id "2"
	And I try to update  name "Jane"
	And I try to update Job "Leader"
	When I send Put Request
	Then  Validate I get a PUT status Code
	And Validate the Put Response fields

Scenario: Patch singleUser
	Given From user Path to patch User id "3"
	And I try to patch update  name "Morpheus"
	And I try to patch update Job "Leader"
	When I send Patch Request
	Then  Validate I get a patch status Code
	And Validate the patch Response fields


Feature: WebpageTesting

@mytag
Scenario: Selecting checkbox will cross out row
	#Given I am on the homepage
	When I select checkbox in row 1
	Then the row 1 is crossed out

Scenario: Entering a new value to the list
	#Given I am on the homepage
	When I enter value "test value" into the text box
	And I click the add button
	Then Value "test value" will be in the list
Feature: TMFeature

A short summary of the feature

@tag1
Scenario: Create time and material record with valid details
	Given I logged into turnup portal successfully
	When I navigate to time and material page
	And I create a new time and material record
	Then The record should be created sucessfully

Scenario Outline: Edit time and material record with valid details
	Given I logged into turn up portal successfully
	When I navigate to time and material page
	And I update '<Description>', '<Code>' and '<Price>' on an exsisting time and material record
	Then The record should have the updated '<Description>', '<Code>' and '<Price>'

	Examples: 
	| Description | Code    | Price   |
	| abc         | Updated | $45.00  |
	| test        | Metric  | $13.00  |
	| Updated     | star    | $342.00 |
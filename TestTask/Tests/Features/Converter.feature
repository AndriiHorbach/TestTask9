Feature: Converter
	In order to check converter functionality
	As a user
	I want to be told the amount of converted currnecy

Scenario: Converter functionality
	Given Converter page is opened
	When I convert 1000 of USD currency
	Then I see correct converted amount in UAH 

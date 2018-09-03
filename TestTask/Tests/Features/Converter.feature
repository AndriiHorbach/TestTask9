Feature: Converter

Scenario: Converter functionality
	Given Converter page is opened
	When I convert 1000 of USD currency
	Then I see correct converted amount in UAH for 1000 of selected currency

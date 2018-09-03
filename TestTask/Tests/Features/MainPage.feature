Feature: MainPage

Background: 
	Given Main page is opened

Scenario Outline: Exchange rates	
	Then <currency> currency sale rate is greater than buy rate
Examples:
	| currency |
	| USD      |
	| EUR      |
	| RUB      |

Scenario: Average fuel price
	Then average price for A-92 is lower that for A-95
 
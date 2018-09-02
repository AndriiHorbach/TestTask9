Feature: MainPage

Scenario Outline: Exchange rates
	Given Main page is opened
	Then For <currency> currency sale rate is greater than buy rate
Examples:
| currency |
| USD      |
| EUR      |
| RUB      |

Feature: LoginFuncionality

Scenario: Login as unregistered user
	Given Main page is opened
	When I login as unregistered user
	| Login        | Password |
	| unregistered | user     |
	Then And see error message Неверный логин или пароль on the login page
	
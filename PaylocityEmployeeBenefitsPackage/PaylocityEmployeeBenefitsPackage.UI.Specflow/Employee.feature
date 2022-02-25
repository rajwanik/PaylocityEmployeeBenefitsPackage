Feature: Employee

Given employee I should be able to add employee, employee dependents and view dependents


Scenario: I should be successfully view employee list
	Given I launch Payroll Employee Benefits Application
	When I click on Employee menu
	Then I should see employees in the system


Scenario: I should be successfully add new employee
	Given I launch Payroll Employee Benefits Application
	And I click on Employee menu
	When I click on create new employee button
	Then I am redirected to create employee page
	And I fill employee name Mary
	And I fill Salary Per Year 52000
	And I click on Create button
	Then employee is successfully created

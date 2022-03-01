# PaylocityEmployeeBenefitsPackage


Business Need: One of the critical functions that we provide for our clients is the ability to pay for their employees’ benefits packages. A portion of these costs are deducted from their paycheck, and we handle that deduction. Please demonstrate how you would code the following scenario: 
1. The cost of benefits is $1000/year for each employee 
2. Each dependent (children and possibly spouses) incurs a cost of $500/year 
3. Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

We’d like to see this calculation used in a web application where employers input employees and their dependents, and get a preview of the costs. This is of course a contrived example. We want to know how you would implement the application structure and calculations and get a brief preview of how you work. 
Please implement a web application based on these assumptions: 
1. All employees are paid $2000 per paycheck before deductions 
2. There are 26 paychecks in a year

**User Story 1**: As an Employer, I should be able to add Employees and their dependents.

**User Story 2**: As an Employer, I should be able to see a preview of the costs. All employees are paid $2000 per paycheck before deductions. There are 26 paychecks in a year.

**User Story 3**: As an Employer, I should be able to see a preview of the costs after deductions. The cost of benefits is $1000/year for each employee. Each dependent (children and possibly spouses) incurs a cost of $500/year. Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

**Technologies Used**:
I used Visual Studio Community Edition 2022 to implement the challenge. Application is implemented in ASP.NET Core MVC (.NET 6) using Entity Framework Core 6. Backed database used is SQL Server LocalDB
Below are nuget packages that are additional used:
1. NUnit: For Unit Testing.
2. FluentAssertions: For Assertions in Unit Testing.
3. Specflow: For UI Automation.
4. Selenium WebDriver: In Specflows to launch UI automation in Chrome.
5. Moq: For mocking in NUnit.

**CSS**:
I have used Flatly theme from https://bootswatch.com/

**Project Breakdown**:
There are 11 projects in the solution. 5 of them contain code and 6 of them are for Unit/UI Automation Testing.

5 projects that contain code are below:
1. PaylocityEmployeeBenefitsPackage - This is the main project containing Controllers and Views.
2. PaylocityEmployeeBenefitsPackage.Business - This is the meat of the project containing crtical Business Logic. I am calling this Business Layer.
3. PaylocityEmployeeBenefitsPackage.DataAccess - This Data Access Layer. Containing all repository for accessing the database.
4. PaylocityEmployeeBenefitsPackage.Models - This project contains all Models
5. PaylocityEmployeeBenefitsPackage.Utility - This Project contains common code that can be used in all layers.

6 projects that contain NUnit/UI Automation:
1. PaylocityEmployeeBenefitsPackage.Business.UnitTest - This project contains NUnit for all business layer.
2. PaylocityEmployeeBenefitsPackage.Conrollers.UnitTest - This project contains NUnit for all controllers. Mocking of dependencies are done using Moq.
3. PaylocityEmployeeBenefitsPackage.DataAccess.UnitTest - This project contains NUnit for all data access layer.  Mocking of dependencies are done using Moq.
4. PaylocityEmployeeBenefitsPackage.Models.UnitTest - This project contains NUnit for all models (validation).
5. PaylocityEmployeeBenefitsPackage.UI.Specflow - This project contains Specflow (https://specflow.org/) for all business layer. This project uses Selenium WebDriver to launch these test in Chrome and tested them automatically.
6. PaylocityEmployeeBenefitsPackage.UnitTest.Common - This project contains common code that can be used across all test projects.

**Database**:
Database that I used was named PaylocityPayroll in my local localDB instance named (localdb)\\MSSQLLocalDB
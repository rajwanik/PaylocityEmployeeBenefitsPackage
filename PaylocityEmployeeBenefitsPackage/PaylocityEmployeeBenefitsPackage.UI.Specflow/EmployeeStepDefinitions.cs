using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using PaylocityEmployeeBenefitsPackage.Controllers;
using PaylocityEmployeeBenefitsPackage.Models;
using PaylocityEmployeeBenefitsPackage.UI.Specflow.Common;
using TechTalk.SpecFlow;

namespace PaylocityEmployeeBenefitsPackage.UI.Specflow
{
    [Binding]
    public class EmployeeStepDefinitions
    {
        private const string CreateEmployeeLandingPage = $"{nameof(Employee)}/{nameof(EmployeeController.Create)}";
        private const string EmployeeIndexLandingPage = $"{nameof(Employee)}";

        [Given(@"I launch Payroll Employee Benefits Application")]
        public void GivenILaunchPayrollEmployeeBenefitsApplication()
        {
            WebDriverContext.Current.Navigate().GoToUrl("https://localhost:7227/");
        }

        [When(@"I click on Employee menu")]
        [Given(@"I click on Employee menu")]
        public void WhenIClickOnEmployeeMenu()
        {
            var element = WebDriverContext.Current.WaitForElementToBeVisible(By.Id("employeeNavLink"));
            element.Click();
        }

        [Then(@"I should see employees in the system")]
        public void ThenIShouldSeeEmployeesInTheSystem()
        {
            WebDriverContext.Current.WaitForElementToBeVisible(By.Id("employeeList"));
        }

        [When(@"I click on create new employee button")]
        public void WhenIClickOnCreateNewEmployeeButton()
        {
            EmployeeHelper.ClickButton(By.Id("createNewEmployee"));
        }

        [Then(@"I am redirected to create employee page")]
        public void ThenIAmRedirectedToCreateEmployeePage()
        {
            Assert.IsTrue(WebDriverContext.Current.Url.EndsWith(CreateEmployeeLandingPage), string.Format("Incorrect Landing Page expected {0}, but was {1}", CreateEmployeeLandingPage, WebDriverContext.Current.Url));
        }

        [Then(@"I fill employee name (.*)")]
        public void ThenIFillEmployeeName(string employeeName)
        {
            WebDriverContext.Current.SetText("employeeNameText", employeeName);
        }

        [Then(@"I fill Salary Per Year (.*)")]
        public void ThenIFillSalaryPerYear(string salary)
        {
            WebDriverContext.Current.SetText("employeeSalaryText", salary);
        }

        [Then(@"I click on Create button")]
        public void ThenIClickOnCreateButton()
        {
            EmployeeHelper.ClickButton(By.Id("employeeCreateButton"));
        }

        [Then(@"employee is successfully created")]
        public void ThenEmployeeIsSuccessfullyCreated()
        {
            Assert.IsTrue(WebDriverContext.Current.Url.EndsWith(EmployeeIndexLandingPage), string.Format("Incorrect Landing Page expected {0}, but was {1}", EmployeeIndexLandingPage, WebDriverContext.Current.Url));
        }

        [Then(@"I should see the following column title in (.*)")]
        public void ThenIShouldSeeTheFollowingColumnTitle(string controlId, Table table)
        {
            var heads = WebDriverContext.Current.FindElements(By.XPath("//table[@id='" + controlId + "']//thead//tr[1]//th"));
            int i = 0;

            foreach (var tableRow in table.Rows)
            {
                
                var value = tableRow["ColumnTitle"];
                heads[i].Text.Should().Be(value, $"Expected Value: {heads[i].Text} does not match with actual value {value}");
                i++;
            }
        }



    }
}

using PaylocityEmployeeBenefitsPackage.Business.Interfaces;
using PaylocityEmployeeBenefitsPackage.Models;
using PaylocityEmployeeBenefitsPackage.Utility;

namespace PaylocityEmployeeBenefitsPackage.Business
{
    public class DeductionCalculator : IDeductionCalculator
    {
        public double CalculateBenefitDeduction(Employee employee)
        {
            double employeeDeductionAmount = CalculateEmployeeBenefitDeduction(employee);

            double employeeDependentDeductionAmount = CalulateDependentBenefitDeduction(employee);
            var employeeSalaryAfterDeduction = Constants.EmployeePayPerPayCheckBeforeDeductions - (employeeDeductionAmount + employeeDependentDeductionAmount);
            
            return employeeSalaryAfterDeduction.ToEvenRound(Constants.PayRoundDecimals);
        }

        public double CalculateEmployeeBenefitDeduction(Employee employee)
        {
            var employeeBenefitDeductionPerPayCheck = Constants.EmployeeBenefitCostPerYear / 26;

            return CalculateBenefitCostAfterDiscount(employee.Name, employeeBenefitDeductionPerPayCheck).ToEvenRound(Constants.PayRoundDecimals);

        }

        public double CalulateDependentBenefitDeduction(Employee employee)
        {
            var employeeDependentBenefitDeductionPerPayCheck = Constants.EmployeeDependentBenefitCostPerYear / 26;

            double deductionAmount = 0;

            var employeeDependents = employee.Dependents?.ToList();
            if (employeeDependents != null)
            {
                foreach (var employeeDependent in employeeDependents)
                {
                    deductionAmount = deductionAmount + CalculateBenefitCostAfterDiscount(employeeDependent.Name, employeeDependentBenefitDeductionPerPayCheck);
                }
            }
            return deductionAmount.ToEvenRound(Constants.PayRoundDecimals);
        }

        public IEnumerable<Employee> GetEmployeeSalaryAfterDeduction(IEnumerable<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employee.SalaryAfterDeduction = CalculateBenefitDeduction(employee);
                employee.EmployeeBenefitCostBeforeDeduction = CalculateEmployeeBenefitDeduction(employee);
                employee.EmployeeDependentBenefitCostBeforeDeduction = CalulateDependentBenefitDeduction(employee);
            }

            return employees;
        }

        private double CalculateBenefitCostAfterDiscount(string name, double benefitAmountPerPayCheck)
        {
            double benefitCostAfterDiscount = benefitAmountPerPayCheck;
            if (name.StartsWith("A"))
            {
                benefitCostAfterDiscount = benefitAmountPerPayCheck - benefitAmountPerPayCheck * Constants.DiscountRate;
            }
            return benefitCostAfterDiscount;
        }
    }
}
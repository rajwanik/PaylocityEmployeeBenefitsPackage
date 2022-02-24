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

            return employeeDeductionAmount + employeeDependentDeductionAmount;
        }

        public double CalculateEmployeeBenefitDeduction(Employee employee)
        {
            var employeeBenefitDeductionPerPayCheck = Constants.EmployeeBenefitCostPerYear / 26;

            return CalculateBenefitCostAfterDiscount(employee.Name, employeeBenefitDeductionPerPayCheck);

        }

        public double CalulateDependentBenefitDeduction(Employee employee)
        {
            var employeeDependentBenefitDeductionPerPayCheck = Constants.EmployeeDependentBenefitCostPerYear / 26;

            double deductionAmount = 0;

            var employeeDependents = employee.Dependents.ToList();
            foreach (var employeeDependent in employeeDependents)
            {
                deductionAmount = deductionAmount + CalculateBenefitCostAfterDiscount(employeeDependent.Name, employeeDependentBenefitDeductionPerPayCheck);
            }
            return deductionAmount;
        }

        private double CalculateBenefitCostAfterDiscount(string name, double benefitAmountPerPayCheck)
        {
            if (name.StartsWith("A"))
            {
                return benefitAmountPerPayCheck - benefitAmountPerPayCheck * Constants.DiscountRate;
            }
            return benefitAmountPerPayCheck;
        }
    }
}
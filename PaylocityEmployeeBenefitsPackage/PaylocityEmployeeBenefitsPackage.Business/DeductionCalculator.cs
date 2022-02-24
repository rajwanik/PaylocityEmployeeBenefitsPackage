using PaylocityEmployeeBenefitsPackage.Business.Interfaces;
using PaylocityEmployeeBenefitsPackage.Models;
using PaylocityEmployeeBenefitsPackage.Utility;

namespace PaylocityEmployeeBenefitsPackage.Business
{
    public class DeductionCalculator : IDeductionCalculator
    {
        public double CalculateDeduction(Employee employee)
        {
            var employeeBenefitDeductionPerPayCheck = Constants.EmployeeBenefitCostPerYear / 26;
            var employeeDependentBenefitDeductionPerPayCheck = Constants.EmployeeDependentBenefitCostPerYear / 26;

            double deductionAmount = CalculateBenefitCostAfterDiscount(employee.Name, employeeBenefitDeductionPerPayCheck);

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
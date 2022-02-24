using PaylocityEmployeeBenefitsPackage.Models;

namespace PaylocityEmployeeBenefitsPackage.Business.Interfaces
{
    public interface IDeductionCalculator
    {
        //Calculates deduction for benefits for employees and dependents.
        double CalculateDeduction(Employee employee);
    }
}

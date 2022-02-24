using PaylocityEmployeeBenefitsPackage.Models;

namespace PaylocityEmployeeBenefitsPackage.Business.Interfaces
{
    public interface IDeductionCalculator
    {
        //Calculates deduction for benefits for employees and dependents.
        double CalculateBenefitDeduction(Employee employee);

        //Calculate deduction for benefits for employee
        double CalculateEmployeeBenefitDeduction(Employee employee);

        //Calculate deduction for benefits of employee dependents
        double CalulateDependentBenefitDeduction(Employee employee);

        //Calculates deduction for all employees and their dependents
        IEnumerable<Employee> GetEmployeeSalaryAfterDeduction(IEnumerable<Employee> employees);
    }
}

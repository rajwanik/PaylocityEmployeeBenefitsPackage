namespace PaylocityEmployeeBenefitsPackage.UnitTest.Common.TestData
{
    public class EmployeeBenefitDeductionTestData
    {
        public EmployeeBenefitDeductionTestData(int employeeId, int numberOfDependents, bool employeeNameStartsWithA, int numberOfDependentsNameStartingWithA, double salaryPerYear, double expectedBenefitAfterDeduction, double expectedEmployeeBenefitAfterDeduction, double expectedEmployeeDependentBenefitAfterDeduction)
        {
            EmployeeId = employeeId;
            NumberOfDependents = numberOfDependents;
            EmployeeNameStartsWithA = employeeNameStartsWithA;
            NumberOfDependentsNameStartingWithA = numberOfDependentsNameStartingWithA;
            SalaryPerYear = salaryPerYear;
            ExpectedBenefitAfterDeduction = expectedBenefitAfterDeduction;
            ExpectedEmployeeBenefitAfterDeduction = expectedEmployeeBenefitAfterDeduction;
            ExpectedEmployeeDependentBenefitAfterDeduction = expectedEmployeeDependentBenefitAfterDeduction;
        }

        public int EmployeeId { get; set; }
        public int NumberOfDependents { get; set; }
        public bool EmployeeNameStartsWithA { get; set; }
        public int NumberOfDependentsNameStartingWithA { get; set; }
        public double SalaryPerYear { get; set; }
        public double ExpectedBenefitAfterDeduction { get; set; }

        public double ExpectedEmployeeBenefitAfterDeduction { get; set; }

        public double ExpectedEmployeeDependentBenefitAfterDeduction { get; set; }
    }

    public class EmployeeBenefitDeductionTestDataList
    {
        public List<EmployeeBenefitDeductionTestData> EmlpoyeeList { get; set; }
    }
}

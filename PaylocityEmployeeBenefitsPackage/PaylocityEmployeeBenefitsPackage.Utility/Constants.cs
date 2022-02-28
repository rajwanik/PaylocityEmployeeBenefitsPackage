namespace PaylocityEmployeeBenefitsPackage.Utility
{
    public static class Constants
    {
        public const double EmployeeBenefitCostPerYear = 1000;
        public const double EmployeeDependentBenefitCostPerYear = 500;
        public const int NumberOfPayChecksPerYear = 26;
        public const double DiscountRate = 0.1;
        public const double EmployeePayPerPayCheckBeforeDeductions = 2000;
        public const int PayRoundDecimals = 2;

        public const string EmployeIDViewDataKey = "EmployeeID";

        public const string FieldIsRequiredErrorMessage = "The {0} field is required.";

        #region EmployeeModel Validation Error Messages
        //The Name field is required.
        public const string EmployeeNameErrorMessage = "Name cannot exceed 100 characters.";
        #endregion
    }
}

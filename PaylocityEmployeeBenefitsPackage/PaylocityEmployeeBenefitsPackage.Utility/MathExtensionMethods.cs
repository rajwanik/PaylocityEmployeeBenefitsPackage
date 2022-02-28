namespace PaylocityEmployeeBenefitsPackage.Utility
{
    public static class MathExtensionMethods
    {
        public static double ToEvenRound(this double value, int decimals)
        {
            return Math.Round(value, decimals, MidpointRounding.ToEven);
        }
    }
}

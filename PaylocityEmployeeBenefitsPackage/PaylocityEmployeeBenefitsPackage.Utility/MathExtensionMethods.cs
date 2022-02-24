using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

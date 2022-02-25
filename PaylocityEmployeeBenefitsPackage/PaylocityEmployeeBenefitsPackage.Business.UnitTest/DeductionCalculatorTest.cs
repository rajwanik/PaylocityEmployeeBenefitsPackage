using NUnit.Framework;

namespace PaylocityEmployeeBenefitsPackage.Business.UnitTest
{
    public class DeductionCalculatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(0,false,0)]
        [TestCase(0, true, 0)]
        [TestCase(1,false,0)]
        [TestCase(1, true, 1)]
        [TestCase(2,false,0)]
        [TestCase(2, true, 0)]
        [TestCase(2, true, 1)]
        [TestCase(2, true, 2)]
        public void CalculateBenefitDeductionTest(int numberOfDependents,bool employeeNameStartsWithA, int numberOfDependentsNameStartingWithA)
        {
            Assert.Pass();
        }
    }
}
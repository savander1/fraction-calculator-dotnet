using fraction_calculator_dotnet.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace fraction_calculator_dotnet.Tests
{
    [TestClass]
    public class FractionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Ctr_DenominiatorZero_ThrowsException()
        {
            new Fraction(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Invert_NumeratorZero_ThrowsException()
        {
            var frac = new Fraction(0, 2);

            frac.Invert();
        }

        [TestMethod]
        public void Invert_FractionNegative_StillNegative()
        {
            var frac = new Fraction(-1, 2);

            frac.Invert();

            Assert.IsTrue(frac.Numerator < 0);
        }
    }
}

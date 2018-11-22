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

        [TestMethod]
        public void Reduce_TwoQuarters_ToOneHalf()
        {
            var frac = new Fraction(2, 4);
            var expected = new Fraction(1, 2);

            frac.Reduce();

            Assert.AreEqual(expected, frac);
        }

        [TestMethod]
        public void TryParse_ValidFractionPassed_ReturnsTrue()
        {
            var toTest = "1/2";
            var expected = new Fraction(1, 2);

            var result = Fraction.TryParse(toTest, out var actual);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParse_WholeNumberPassed_ReturnsTrue()
        {
            var toTest = "3";
            var expected = new Fraction(3,1);

            var result = Fraction.TryParse(toTest, out var actual);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParse_InvalidFractionPassed_ReturnsTrue()
        {
            var toTest = "1/2/3";

            var result = Fraction.TryParse(toTest, out var actual);

            Assert.IsFalse(result);
            Assert.IsNull(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TryParse_ZeroDenominator_ThrowsException()
        {
            var toTest = "1/0";

            Fraction.TryParse(toTest, out var actual);
        }

        [TestMethod]
        public void TryParse_ValidNegativeFraction_ReturnsTrue()
        {
            var toTest = "-1/2";
            var expected = new Fraction(-1, 2);

            var result = Fraction.TryParse(toTest, out var actual);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParse_NegativeDenominator_ReturnsTrue()
        {
            var toTest = "1/-2";
            var expected = new Fraction(-1, 2);

            var result = Fraction.TryParse(toTest, out var actual);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TryParse_NegativeNumeratorAndDenominator_ReturnsTrue()
        {
            var toTest = "-1/-2";
            var expected = new Fraction(1, 2);

            var result = Fraction.TryParse(toTest, out var actual);

            Assert.IsTrue(result);
            Assert.AreEqual(expected, actual);
        }
    }
}


using fraction_calculator_dotnet.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace fraction_calculator_dotnet.Tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        [DataRow("1/2", "1/2", "1")]
        [DataRow("1/2", "1/3", "5/6")]
        [DataRow("1/2", "1/4", "3/4")]
        [DataRow("1/2", "1/8", "5/8")]
        public void Add_ValidValuesPassed_ResultAsExpected(string first, string second, string result)
        {
            Fraction.TryParse(first, out var a);
            Fraction.TryParse(second, out var b);
            Fraction.TryParse(result, out var expected);

            var actual = a.Add(b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("1/2", "1/2", "0/1")]
        [DataRow("1/2", "1/3", "1/6")]
        [DataRow("1/2", "1/4", "1/4")]
        [DataRow("1/2", "1/8", "3/8")]
        public void Subtract_ValidValuesPassed_ResultAsExpected(string first, string second, string result)
        {
            Fraction.TryParse(first, out var a);
            Fraction.TryParse(second, out var b);
            Fraction.TryParse(result, out var expected);

            var actual = a.Subtract(b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("1/2", "1/2", "1/4")]
        [DataRow("1/2", "1/3", "1/6")]
        [DataRow("1/2", "1/4", "1/8")]
        [DataRow("1/2", "1/8", "1/16")]
        [DataRow("3/2", "1/8", "3/16")]
        public void Multiply_ValidValuesPassed_ResultAsExpected(string first, string second, string result)
        {
            Fraction.TryParse(first, out var a);
            Fraction.TryParse(second, out var b);
            Fraction.TryParse(result, out var expected);

            var actual = a.Multiply(b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("1/2", "1/2", "1")]
        [DataRow("1/2", "1/3", "3/2")]
        [DataRow("1/2", "1/4", "2")]
        [DataRow("1/2", "1/8", "4")]
        public void Divide_ValidValuesPassed_ResultAsExpected(string first, string second, string result)
        {
            Fraction.TryParse(first, out var a);
            Fraction.TryParse(second, out var b);
            Fraction.TryParse(result, out var expected);

            var actual = a.Divide(b);

            Assert.AreEqual(expected, actual);
        }
    }
}
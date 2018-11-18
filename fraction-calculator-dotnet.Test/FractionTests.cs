using Microsoft.VisualStudio.TestTools.UnitTesting;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Test
{
   [TestClass]
    public class FractionTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Ctr_DenominatorZero_ThrowsException()
        {
            new Fraction(1,0);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using fraction_calculator_dotnet.Render;
using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Tests
{
    [TestClass]
    public class BuilderRendererTests
    {
        private static readonly IRenderer Renderer = RenderFactory.GetRenderer(Mode.Builder);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Render_NullPassed_ThrowsException()
        {
            Renderer.Render(null);
        }

        [TestMethod]
        [DataRow("1/3", "1/2")]
        [DataRow("1/33", "1/32")]
        public void Render_ValidFractionPassed_ReturnsAsExpected(string first, string second)
        {
            Fraction.TryParse(first, out Fraction passed);
            Fraction.TryParse(second, out var expected);

            var actual = Renderer.Render(passed);

            Assert.AreEqual(expected, actual);
        }
    }
}
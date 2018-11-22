using Microsoft.VisualStudio.TestTools.UnitTesting;
using fraction_calculator_dotnet.Render;
using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Tests
{
    [TestClass]
    public class DefaultRendererTests
    {
        private static readonly IRenderer Renderer = RenderFactory.GetRenderer(Mode.Standard);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Render_NullPassed_ThrowsException()
        {
            Renderer.Render(null);
        }

        [TestMethod]
        public void Render_ValidFractionPassed_ReturnsAsExpected()
        {
            var expected = new Fraction(1,1);

            var actual = Renderer.Render(expected);

            Assert.AreSame(expected, actual);
        }
    }
}
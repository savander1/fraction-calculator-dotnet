
using Microsoft.VisualStudio.TestTools.UnitTesting;
using fraction_calculator_dotnet.Render;

namespace fraction_calculator_dotnet.Tests
{
    [TestClass]
    public class RenderFactoryTests
    {
        [TestMethod]
        public void GetRenderer_StandardMode_ReturnsAsExpected()
        {
            var result = RenderFactory.GetRenderer(Mode.Standard);

            Assert.IsInstanceOfType(result, typeof(DefaultRenderer));
        }

        [TestMethod]
        public void GetRenderer_BuilderMode_ReturnsAsExpected()
        {
            var result = RenderFactory.GetRenderer(Mode.Builder);

            Assert.IsInstanceOfType(result, typeof(BuilderRenderer));
        }
    }
}
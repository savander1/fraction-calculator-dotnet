using System;
namespace fraction_calculator_dotnet.Render
{
    public static class RenderFactory
    {
        public static IRenderer GetRenderer(Mode mode)
        {
            switch (mode)
            {
                case Mode.Builder:
                    return new BuilderRenderer();
                default:
                    return new DefaultRenderer();
            }
        }
    }
}

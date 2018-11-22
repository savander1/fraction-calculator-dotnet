using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Render
{
    public class DefaultRenderer : IRenderer
    {
        public Fraction Render(Fraction fraction)
        {
            if (fraction == null) throw new ArgumentNullException(nameof(fraction));
            return fraction;
        }
    }
}

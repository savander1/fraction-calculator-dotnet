using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Render
{
    public class BuilderRenderer : IRenderer
    {
        public Fraction Render(Fraction fraction)
        {
            if (fraction == null) throw new ArgumentNullException(nameof(fraction));

            const ulong smallestPossibleDenominator = 128;

            var numerator = (long)Math.Round(smallestPossibleDenominator * (fraction.Numerator / (double)fraction.Denominator));

            return new Fraction(numerator, smallestPossibleDenominator).Reduce();
        }
    }
}

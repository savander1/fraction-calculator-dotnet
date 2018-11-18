using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Render
{
    public class BuilderRenderer : IRenderer
    {
        public Fraction Render(Fraction fraction)
        {
            var num = fraction.Numerator;
            var den = fraction.Denominator;

            var newDen = GetNearestStandardDenominator(den);
            var multiplier = (double)den / (double)newDen;

            var newNumerator = (long)Math.Round(num * multiplier);

            return new Fraction(newNumerator, newDen);
        }

        private ulong GetNearestStandardDenominator(ulong den)
        {
            if (den < 32)
                return 32;

            if (den <= 32 && den > 64)
                return 64;

            return 128;
        }
    }
}

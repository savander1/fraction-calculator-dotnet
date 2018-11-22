using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Render
{
    public class BuilderRenderer : IRenderer
    {
        public Fraction Render(Fraction fraction)
        {
            if (fraction == null) throw new ArgumentNullException(nameof(fraction));

            var num = fraction.Numerator;
            var den = fraction.Denominator;

            // cacluate to the nearest 1/128
            // round the numerator to the nearest whole number
            // simplify/reduce

            var newDen = GetNearestStandardDenominator(den);
            var multiplier = (double)den / (double)newDen;

            var newNumerator = (long)Math.Round(num * multiplier);

            return new Fraction(newNumerator, newDen);
        }

        private ulong GetNearestStandardDenominator(ulong den)
        {
            if (den == 1) 
                return 1;
            if (den == 2)
                return 2;
            if (den >= 3 && den < 7)
                return 4;
            if (den >= 7 && den < 11)
                return 8;
            if (den >= 11 && den < 19)
                return 16;
            if (den >= 19 && den < 35)
                return 32;
            if (den >= 35 && den < 67)
                return 64;

            return 128;
        }
    }
}

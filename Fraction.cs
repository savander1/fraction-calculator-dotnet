using System;
using fraction_calculator_dotnet.Operators;

namespace fraction_calculator_dotnet
{
    public class Fraction
    {
        public long Numerator {get;set;}
        public ulong Denominator {get;set;}

        public Fraction(long numerator, ulong denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction Invert()
        {
            var temp = Numerator;
            Numerator = (long)Denominator;
            if (temp < 0)
            {
                Numerator *= -1;
            }
            Denominator = (ulong)Math.Abs(temp);

            return this;
        }

        public Fraction Simplify()
        {
            var gcdOperator = new Gcd();
            var gcd = gcdOperator.Execute((ulong)Math.Abs(Numerator), Denominator);
            var negative = Numerator < 0;
            Numerator  /= (long)gcd;
            if (negative) Numerator *= -1;

            Denominator /= (ulong)gcd;

            return this;
        }

        public override string ToString()
        {
            var dec = (decimal)(Numerator/(long)Denominator);
            if (dec == 1)
                return 1.ToString();

            return  $"{Numerator}/{Denominator}";
        }
    }
}
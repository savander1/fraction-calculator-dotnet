using System;
using fraction_calculator_dotnet.Operators;

namespace fraction_calculator_dotnet.Entity
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

        public static bool TryParse(string s, out Fraction f)
        {
            var parts = s.Split('/');

            if (parts.Length != 2)
            {
                f = null;
                return false;
            }

            if (!long.TryParse(parts[0], out long numerator))
            {
                f = null;
                return false;
            }

            if (!ulong.TryParse(parts[1], out ulong denominator))
            {
                f = null;
                return false;
            }

            f = new Fraction(numerator, denominator);
            return true;
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
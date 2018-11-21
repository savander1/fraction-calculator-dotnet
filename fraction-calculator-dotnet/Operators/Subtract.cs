using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Operators
{
    internal class Subtract : IOperator<Fraction>
    {
        public Fraction Execute(Fraction a, Fraction b)
        {
            var operatorLcd = new Lcd();
            var denominator = operatorLcd.Execute(a.Denominator, b.Denominator);
            a.Numerator = a.Numerator * (long)Math.Abs(denominator / (float)a.Denominator);
            b.Numerator = b.Numerator * (long)Math.Abs(denominator / (float)b.Denominator);

            var numerator = a.Numerator - b.Numerator;
            
            return new Fraction(numerator, denominator);
        }
    }
}
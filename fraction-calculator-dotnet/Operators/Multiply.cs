using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Operators
{
    internal class Mulitply : IOperator<Fraction>
    {
        public Fraction Execute(Fraction a, Fraction b)
        {
            var operatorLcd = new Lcd();
            var lcd = operatorLcd.Execute(a.Denominator, b.Denominator);
            a.Numerator = a.Numerator * (long)Math.Abs(lcd / (float)a.Denominator);
            b.Numerator = b.Numerator * (long)Math.Abs(lcd / (float)b.Denominator);

            var numerator = a.Numerator * b.Numerator;
            var denominator = a.Denominator * b.Denominator;
            
            return new Fraction(numerator, denominator);
        }
    }
}
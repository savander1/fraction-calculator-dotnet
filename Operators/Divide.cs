using System;

namespace fraction_calculator_dotnet.Operators
{
    internal class Divide : IOperator<Fraction>
    {
        public Fraction Execute(Fraction a, Fraction b)
        {
            var operatorLcd = new Lcd();
            var lcd = operatorLcd.Execute(a.Denominator, b.Denominator);
            a.Numerator = a.Numerator * (long)Math.Abs(lcd / (float)a.Denominator);
            b.Numerator = b.Numerator * (long)Math.Abs(lcd / (float)b.Denominator);
            a.Denominator = lcd;
            b.Denominator = lcd;
            b.Invert();

            var numerator = a.Numerator * b.Numerator;
            var denominator = a.Denominator * b.Denominator;

            return new Fraction(numerator, denominator);
        }
    }
}
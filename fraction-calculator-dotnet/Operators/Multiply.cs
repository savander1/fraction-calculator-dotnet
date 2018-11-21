using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet.Operators
{
    internal class Multiply : IOperator<Fraction>
    {
        public Fraction Execute(Fraction a, Fraction b)
        {
            var numerator = a.Numerator * b.Numerator;
            var denominator = a.Denominator * b.Denominator;
            
            return new Fraction(numerator, denominator);
        }
    }
}
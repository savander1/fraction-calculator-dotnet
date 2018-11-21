using System;
using fraction_calculator_dotnet.Entity;
using fraction_calculator_dotnet.Operators;

namespace fraction_calculator_dotnet
{
    public static class FluentOperators
    {
        public static Fraction Add(this Fraction a, Fraction b)
        {
            var op = new Add();
            return op.Execute(a, b);
        }

        public static Fraction Subtract(this Fraction a, Fraction b)
        {
            var op = new Subtract();
            return op.Execute(a, b);
        }

        public static Fraction Multiply(this Fraction a, Fraction b)
        {
            var op = new Multiply();
            return op.Execute(a, b);
        }

        public static Fraction Divide(this Fraction a, Fraction b)
        {
            var op = new Divide();
            return op.Execute(a, b);
        }
    }
}
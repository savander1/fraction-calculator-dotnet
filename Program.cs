using System;
using fraction_calculator_dotnet.Entity;

namespace fraction_calculator_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var half = new Fraction(1,2);
            var third = new Fraction(1,3);
            var fifth = new Fraction(1,5);
            var twoFifths = new Fraction(2,5);

            var calculator = new Calculator();
            calculator.Mode = Mode.Builder;

            calculator.AddFraction(half);
            calculator.AddOperation(new Operators.Add());
            calculator.AddFraction(third);

            var value = calculator.Calculate();

            Console.WriteLine(value);
        }
    }
}

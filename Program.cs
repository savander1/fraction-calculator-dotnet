using System;

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

            var value = half.Divide(third);

            Console.WriteLine(value);
        }
    }
}

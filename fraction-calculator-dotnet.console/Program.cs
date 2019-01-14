using System;
using fraction_calculator_dotnet;

namespace fraction_calculator_dotnet.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();

            var calc = Parser.Parse(args);

            var result = calc.Calculate();

            Console.WriteLine(result);
        }
    }
}

using System;

namespace fraction_calculator_dotnet.Operators
{
    internal class Lcd : IOperator<ulong>
    {
        public ulong Execute(ulong a, ulong b)
        {
            var operatorGcd = new Gcd();
            var gcd = operatorGcd.Execute(a, b);
            
            return (a / gcd) * b;
        }
    }
}
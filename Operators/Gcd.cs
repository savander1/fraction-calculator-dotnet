using System;

namespace fraction_calculator_dotnet.Operators
{
    internal class Gcd : IOperator<ulong>
    {
        public ulong Execute(ulong a, ulong b)
        {
            if (a == 0 && b == 0) throw new DivideByZeroException();

            if (a == 0) return b;
            if (b == 0) return a;

            var shift = 0;

            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do 
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    var temp = b;
                    b = a;
                    a = temp;
                }

                b = b - a;
            } while (b != 0);

            return a << shift;
        }
    }
}
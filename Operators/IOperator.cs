using System;

namespace fraction_calculator_dotnet.Operators
{
    internal interface IOperator<T>
    {
        T Execute(T a, T b);
    }
}
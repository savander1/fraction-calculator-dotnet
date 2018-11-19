using System;

namespace fraction_calculator_dotnet.Operators
{
    public interface IOperator<T>
    {
        T Execute(T a, T b);
    }
}
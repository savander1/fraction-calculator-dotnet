using System;
using System.Collections;
using fraction_calculator_dotnet.Entity;
using fraction_calculator_dotnet.Operators;
using fraction_calculator_dotnet.Render;

namespace fraction_calculator_dotnet
{
    public enum Mode {
        Fraction,
        Builder
    }

    public class Calculator
    {
        public Mode Mode { get; set; }
        private readonly Stack _operations;

        public Calculator()
        {
            _operations = new Stack();
        }



        public void AddFraction(Fraction fraction)
        {
            if (_operations.Count > 0 && _operations.Peek() is Fraction)
            {
                throw new InvalidOperationException();
            }

            _operations.Push(fraction);
        }

        public void AddOperation(IOperator<Fraction> op)
        {
            if (_operations.Count > 0 && !(_operations.Peek() is Fraction))
            {
                throw new InvalidOperationException();
            }
            _operations.Push(op);
        }

        public void Undo()
        {
            _operations.Pop();
        }

        public Fraction Calculate()
        {
            var a = _operations.Pop() as Fraction;
            var op = _operations.Pop() as IOperator<Fraction>;
            var b = _operations.Pop() as Fraction;

            var result = op.Execute(a, b).Simplify();

            var renderer = RenderFactory.GetRenderer(Mode);

            return renderer.Render(result);
        }

    }
}

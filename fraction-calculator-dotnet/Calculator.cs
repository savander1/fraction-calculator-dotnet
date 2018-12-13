using System;
using System.Collections;
using fraction_calculator_dotnet.Entity;
using fraction_calculator_dotnet.Operators;
using fraction_calculator_dotnet.Render;

namespace fraction_calculator_dotnet
{
    public enum Mode {
        Standard,
        Builder
    }

    public sealed class Calculator
    {
        public Mode Mode { get; set; }
        private readonly Stack _operations;

        public Calculator()
        {
            _operations = new Stack();
        }

        public void AddFraction(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

            if (Fraction.TryParse(value,out var fraction))
            {
                AddFraction(fraction);
                return;
            }
        }

        public void AddFraction(Fraction fraction)
        {
            if (fraction == null) throw new ArgumentNullException(nameof(fraction));

            if (_operations.Count > 0 || _operations.Peek() is Fraction)
            {
                throw new InvalidOperationException();
            }

            _operations.Push(fraction);
        }

        public void AddOperation(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

            var operation = GetOperator(value);
            AddOperation(operation);
        }

        public void AddOperation(IOperator<Fraction> op)
        {
            if (op == null) throw new ArgumentNullException(nameof(op));

            if (_operations.Count > 1 || !(_operations.Peek() is Fraction))
            {
                throw new InvalidOperationException();
            }
            _operations.Push(op);
        }

        public void Undo()
        {
            _operations.Pop();
        }

        public void ClearAll()
        {
            _operations.Clear();
        }

        public Fraction Calculate()
        {
            var a = _operations.Pop() as Fraction;
            var op = _operations.Pop() as IOperator<Fraction>;
            var b = _operations.Pop() as Fraction;

            var result = op.Execute(a, b).Reduce();

            var renderer = RenderFactory.GetRenderer(Mode);

            return renderer.Render(result);
        }

        private IOperator<Fraction> GetOperator(string value)
        {
            switch(value)
            {
                case "+":
                    return new Add();
                case "-":
                    return new Subtract();
                case "*":
                    return new Multiply();
                case "/":
                    return new Divide();
                default:
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

    }
}

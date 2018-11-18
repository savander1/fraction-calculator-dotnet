using System;
using System.Collections;
using fraction_calculator_dotnet.Entity;
using fraction_calculator_dotnet.Operators;

namespace fraction_calculator_dotnet
{
    public enum Mode {
        Fraction,
        Builder
    }

    public class Calculator
    {
        public Mode Mode { get; set; }
        private readonly Queue _operations;

        public Calculator()
        {
            _operations = new Queue();
        }



        public void AddFraction(Fraction fraction)
        {
            if (_operations.Count > 0 && _operations.Peek() is Fraction)
            {
                throw new InvalidOperationException();
            }

            _operations.Enqueue(fraction);
        }

        public void AddOperation(IOperator<Fraction> op)
        {
            if (_operations.Count > 0 && !(_operations.Peek() is Fraction))
            {
                throw new InvalidOperationException();
            }
            _operations.Enqueue(op);
        }

        public void Undo()
        {
            _operations.Dequeue();
        }

        public Fraction Calculate()
        {
            var a = _operations.Dequeue() as Fraction;
            var op = _operations.Dequeue() as IOperator<Fraction>;
            var b = _operations.Dequeue() as Fraction;

            var result = op.Execute(a, b);

        }

    }
}

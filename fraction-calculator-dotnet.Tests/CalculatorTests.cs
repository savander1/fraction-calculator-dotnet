
using System;
using fraction_calculator_dotnet.Entity;
using fraction_calculator_dotnet.Operators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace fraction_calculator_dotnet.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Init()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddFraction_NullPassed_ThrowsException()
        {
            _calculator.AddFraction((Fraction)null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddFraction_FractionAddedTwice_ThrowsException()
        {
            var frac = new Fraction(1,1);
            _calculator.AddFraction(frac);
            _calculator.AddFraction(frac);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddOperation_NullPassed_ThrowsException()
        {
            _calculator.AddOperation((IOperator<Fraction>)null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddOperation_OperationAddedTwice_ThrowsException()
        {
            var op = new Mock<IOperator<Fraction>>();
            _calculator.AddOperation(op.Object);
            _calculator.AddOperation(op.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Undo_ValidArguments_Succeeds()
        {
            var op = new Mock<IOperator<Fraction>>();
            var frac = new Fraction(1,1);
            _calculator.AddFraction(frac);
            _calculator.AddOperation(op.Object);
            _calculator.AddFraction(frac);

            _calculator.Undo();

            _calculator.AddOperation(op.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ClearAll_ValidArguments_Succeeds()
        {
            var op = new Mock<IOperator<Fraction>>();
            var frac = new Fraction(1,1);
            _calculator.AddFraction(frac);
            _calculator.AddOperation(op.Object);
            _calculator.AddFraction(frac);

            _calculator.ClearAll();

            _calculator.AddOperation(op.Object);
        }
    }
}
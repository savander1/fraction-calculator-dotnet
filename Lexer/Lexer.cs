using System;
using System.Text;

namespace fraction_calculator_dotnet
{
    internal class Lexer 
    {
        public void ParseArgs(string[] args)
        {
            var builder = new StringBuilder();
            foreach(var s in args)
            {
                builder.Append(s);
            }

            var commands = builder.ToString().Split(new [] {' ', '\t', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            
        } 

        private class ScanResult
        {
            public Fraction[] Fractions {get; private set;}
            public Op[] Operations {get;private set;}

            public ScanResult(Fraction[] fractions, Op[] ops )
            {
                Fractions = fractions;
                Operations = ops;
            }

            public string Errors {get; set;}

        }

        private enum Op
        {
            Add,
            Sub,
            Mul,
            Div
        };

        static class CommandExtensions
        {
            static ScanResult Scan(this string[] args)
            {
                throw new NotImplementedException();

            }
        }
    }
}
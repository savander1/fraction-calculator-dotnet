using System;
using System.Text;
using System.Collections.Generic;

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

        private LexResult Lex(string[] commands)
        {
            var fractions = new List<Fraction>();
            var ops = new List<Op>();
            for(var i = 0; i < commands.Length; i++)
            {
                var success = Fraction.TryParse(commands[i], out Fraction f);
                if  (success) fractions.Add(f);

                success = TryParseOp(commands[i], out Op op);
                if  (success) ops.Add(op);

                if (!success) return new LexResult(null, null)
                {
                    Errors = $"Invalid: {commands[i]}. Arg pos: {i}"
                };
            }

            return new LexResult(fractions, ops);
        }

        private bool TryParseOp(string s, out Op op)
        {
            switch (s)
            {
                case "+":
                    op = Op.Add;
                    return true;
                case "-":
                    op = Op.Sub;
                    return true;
                case "*":
                    op = Op.Mul;
                    return true;
                case "/":
                    op = Op.Div;
                    return true;
                case "(":
                    op = Op.Open;
                    return true;
                case ")":
                    op = Op.Close;
                    return true;
                default:
                    op = Op.Add;
                    return false;
            }
        }

        private class LexResult
        {
            public IList<Fraction> Fractions {get; private set;}
            public IList<Op> Operations {get;private set;}

            public LexResult(IList<Fraction> fractions, IList<Op> ops )
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
            Div,
            Open,
            Close
        };
    }
}
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
    }
}
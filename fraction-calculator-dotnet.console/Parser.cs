using System;
using fraction_calculator_dotnet;

namespace fraction_calculator_dotnet.console
{
    public class Parser
    {
        public Calculator Parse(string[] args)
        {
            var parts = string.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var calculator = new Calculator();

            for (var i = 0; i < parts.Length; i++)
            {
                
            }
        }

        private bool IsFraction(string arg)
        {
            return arg.IndexOf('/') != -1;
        }
    }
}
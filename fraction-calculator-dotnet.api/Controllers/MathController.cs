using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fraction_calculator_dotnet.Entity;
using fraction_calculator_dotnet.Operators;
using Microsoft.AspNetCore.Mvc;

namespace fraction_calculator_dotnet.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        //TODO: Inject this
        private readonly Calculator _calculator;

        public MathController()
        {
            _calculator = new Calculator();
        }

        [HttpPost("/Frac")]
        public void AddFraction([FromBody] string value)
        {
             _calculator.AddFraction(value);
        }

        [HttpPost("/Op")]
        public void Add([FromBody] string value)
        {
            _calculator.AddOperation(value);
        }

        [HttpGet("/Clear")]
        public void Clear()
        {
            _calculator.Undo();
        }

        [HttpGet("/ClearAll")]
        public void ClearAll()
        {
            _calculator.ClearAll();
        }

        [HttpGet("/Calculate")]
        public Fraction Calculate()
        {
            return _calculator.Calculate();
        }
   }
}

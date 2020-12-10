using Calculator.Interfaces;
using Calculator.Models;
using Enums;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
  
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            this._calculator = calculator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(JsonConvert.SerializeObject(new Expression() { Number = 1 ,Operand = (char)Operations.Add })); ;
        }
        [HttpPost]
        public IActionResult Index([FromBody] Expression operand)
        {
            _calculator.Calculate(operand);
            return Ok(JsonConvert.SerializeObject(_calculator.Answer()));
        }

       
    }
}

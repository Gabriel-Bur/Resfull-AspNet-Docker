using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [Produces("application/json")]
    [Route("api/Calculator")]
    public class CalculatorController : Controller
    {
        // Get api/Calculator/Sum/5/5
        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + 
                    ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }


        // Get api/Calculator/Sub/5/5
        [HttpGet("Sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) -
                    ConvertToDecimal(secondNumber);

                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }


        // Get api/Calculator/Multiply/5/5
        [HttpGet("Multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiply = ConvertToDecimal(firstNumber) *
                    ConvertToDecimal(secondNumber);

                return Ok(multiply.ToString());
            }
            return BadRequest("Invalid Input");
        }


        // Get api/Calculator/Div/5/5
        [HttpGet("Div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) /
                    ConvertToDecimal(secondNumber);

                return Ok(div.ToString());
            }
            return BadRequest("Invalid Input");
        }


        // Get api/Calculator/Mean/5/5
        [HttpGet("Mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) +
                    ConvertToDecimal(secondNumber)) / 2;

                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }


        // Get api/Calculator/SquareRoot/5/5
        [HttpGet("SquareRoot/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var SquareRoot = ConvertToDecimal(firstNumber);

                return Ok(Math.Sqrt(SquareRoot).ToString());
            }
            return BadRequest("Invalid Input");
        }



        #region private
        private double ConvertToDecimal(string number)
        {
            double result;

            if (double.TryParse(number, out result))
            {
                return result;
            }

            return 0;
        }
        private bool IsNumeric(string number)
        {
            double numberParsed;

            bool isNumber = double
                .TryParse(number,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out numberParsed);

            return isNumber;
        }
        #endregion

    }
}
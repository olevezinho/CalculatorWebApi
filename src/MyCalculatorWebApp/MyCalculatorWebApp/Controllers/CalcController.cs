namespace MyCalculatorWebApp.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using ModelClasses;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        /// <summary>
        /// Retrieves the list of values
        /// </summary>
        /// <returns>200 OK</returns>
        // GET api/calc
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Add two number and return the result
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns>200 OK; 404 Bad Request</returns>
        // POST api/values
        [HttpPost("add/{n1}/{n2}")]
        public ActionResult<int> PostNumbers(int n1, int n2)
        {
            Calculator calculator = new Calculator();
            return new ObjectResult(calculator.Add(n1, n2));
        }
    }
}

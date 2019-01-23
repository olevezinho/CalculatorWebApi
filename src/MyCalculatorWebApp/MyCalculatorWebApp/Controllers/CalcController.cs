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
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        [HttpPost("add/{n1}/{n2}")]
        public ActionResult<int> PostNumbers(int n1, int n2)
        {
            Calculator calculator = new Calculator();
            return new ObjectResult(calculator.Add(n1, n2));
        }
    }
}

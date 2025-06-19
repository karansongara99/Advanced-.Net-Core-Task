using Employee_Management_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employee_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        [HttpGet("success")]
        [HttpGet]
        public IActionResult GetSuccess()
        {
            return Ok(new { message = "Success" });
        }

        [HttpGet("fail")]
        public IActionResult GetFailure()
        {
            throw new Exception("Failaure Please Solve the error");
        }
        [HttpPost]
        public IActionResult Create([FromBody] EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                var jsonOutput = JsonConvert.SerializeObject(employee, Formatting.Indented);

                return Ok(new
                {
                    Message = "Employee Data Received",
                    Data = jsonOutput
                });
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IActionResult DeserializeJson([FromBody] string json)
        {
            try
            {
                var employee = JsonConvert.DeserializeObject<EmployeeModel>(json);
                return Ok(new
                {
                    Message = "Employee Data Received",
                    EmployeeModel = employee
                });
            }
            catch (Exception ex) {

                return BadRequest(new
                {
                    Message = "Invalid JSON Format",
                    EmployeeModel = ex
                });
            }
        }  
    }
}

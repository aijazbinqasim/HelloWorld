using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        // Following 2 string types methods are used for just examples to understand about routing.
        //[Route("getallemployees")]
        //[HttpGet]
        //public string GetAllEmployees()
        //{
        //    return "Response from GetAllEmployees Method";
        //}


        //[Route("employee/byid/{id}")]
        //[HttpGet]
        //public string GetEmployeeById(int id)
        //{
        //    return $"Response from GetEmployeeById Method Id: {id}";
        //}



        // Following methods returns "Specific Type Result".
        [Route("getemplist")]
        [HttpGet]
        public IList<EmployeeModel> GetEmployeeList()
        {
            IList<EmployeeModel> employees =
            [
                 new() { ID = 1, Name = "Aijaz", Age = 35 },
                 new() { ID = 2, Name = "Walidad", Age = 30 },
                 new() { ID = 3, Name = "Ghani", Age = 25 },
                 new() { ID = 4, Name = "Umer", Age = 20 }
            ];

            return employees.OrderByDescending(e => e.ID).ToList();
        }

        [Route("getsingleemployee")]
        [HttpGet]
        public EmployeeModel GetSingleEmployee()
        {
            var emp = new EmployeeModel
            {
                ID = 1,
                Name = "Walidad",
                Age = 30
            };

            return emp;
        }


        // Following method returns "Mix Type Result such as data and http status codes".
        [Route("getsingleperson/{id:int}")]
        [HttpGet]
        [ProducesResponseType<EmployeeModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSinglePerson(int id)
        {
            var emp = new EmployeeModel
            {
                ID = id,
                Name = "Walidad",
                Age = 30
            };

            return emp.ID == 1? Ok(emp) : NotFound();
        }


        // Following method returns "Mix Type Result such as data and http status codes along with Specific Type Result".
        [Route("getpersonlist")]
        [HttpGet]
        public ActionResult<IList<EmployeeModel>> GetPersonList()
        {
            IList<EmployeeModel> employees =
            [
                 new() { ID = 1, Name = "Aijaz", Age = 35 },
                 new() { ID = 2, Name = "Walidad", Age = 30 },
                 new() { ID = 3, Name = "Ghani", Age = 25 },
                 new() { ID = 4, Name = "Umer", Age = 20 }
            ];

            return Ok(employees);
        }
    }
}

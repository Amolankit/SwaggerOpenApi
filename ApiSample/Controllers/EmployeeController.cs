using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Gets the list of employee
        /// </summary>
        /// <returns></returns>
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return GetEmployees();
        }

        /// <summary>
        /// Gets the details of the employee of the provided ID
        /// </summary>
        /// <param name="id">Primary Id of the employee</param>
        /// <returns>Employee object</returns>
        /// <returncode>404:- When the Id is not found</returncode>
        /// <returncode>200:- When the Id not found</returncode>
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(404)]
        public Employee Get(int id)
        {
            return GetEmployees().Find(e => e.Id == id);
        }

        // POST: api/Employee
        [HttpPost]
        [Produces("application/json")]
        public Employee Post([FromBody] Employee employee)
        {
            // Logic to create new Employee
            return new Employee();
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            // Logic to update an Employee
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public void Delete(int id)
        {
        }

        private List<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    FirstName= "John",
                    LastName = "Smith",
                    EmailId ="John.Smith@gmail.com"
                },
                new Employee()
                {
                    Id = 2,
                    FirstName= "Jane",
                    LastName = "Doe",
                    EmailId ="Jane.Doe@gmail.com"
                }
            };
        }
    }
}


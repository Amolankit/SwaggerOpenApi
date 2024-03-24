using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EmployeeController : ControllerBase
{
    /// <summary>
    /// Gets the full list of employee
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Returns the list of all employee</response>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok( GetEmployees());
    }

    /// <summary>
    /// Gets the details of the employee of the provided ID
    /// </summary>
    /// <param name="id">Primary Id of the employee</param>
    /// <returns>Employee object</returns>
    /// <remarks>
    /// Sample response:
    ///
    ///    
    ///     {
    ///        "id": 1,
    ///        "firstName": "Alpha",
    ///        "lastName": Beta,
    ///        "emailId": "alpha.beta@delta.com"
    ///     }
    ///
    /// </remarks>
    /// <response code="200">Returns the valid item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">When Server Error happens</response>
    [HttpGet("{id}", Name = "Get")]
    [ProducesResponseType(404)]
    [ProducesResponseType(200)]
    public IActionResult Get(int id)
    {
        try
        {

            if (id <= 0)
                return BadRequest();
            var employee = GetEmployees().Find(e => e.Id == id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
        catch
        {
            return StatusCode(500) ;
        }
    }

    /// <summary>
    /// Adds the new Employee to the collection
    /// </summary>
    /// <param name="employee">Employee object collection</param>
    /// <returns>The employee sent to be added</returns>
    /// <remarks>
    ///
    /// Sample request:
    ///
    ///    
    ///     {
    ///        "id": 1,
    ///        "firstName": "Alpha",
    ///        "lastName": Beta,
    ///        "emailId": "alpha.beta@delta.com"
    ///     }
    ///
    /// 
    /// Sample response:
    ///
    ///    
    ///     {
    ///        "id": 1,
    ///        "firstName": "Alpha",
    ///        "lastName": Beta,
    ///        "emailId": "alpha.beta@delta.com"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Objected Created</response>
    /// <response code="400">Bad Request</response>
    /// <response code="500">Internal server error</response>
    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(404)]
    [ProducesResponseType(201)]
    public IActionResult Post([FromBody] Employee employee)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Email");
            }
            // Logic to create new Employee
            return StatusCode(201);
        }
        catch
        {
            return StatusCode(500);
        }
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


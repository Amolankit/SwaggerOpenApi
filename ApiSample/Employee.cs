
namespace ApiSample;

/// <summary>
/// The Employee class to store the data
/// </summary>
public class Employee
{
    /// <summary>
    /// Id of the employee
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// First Name of the employee(nullable)
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Last name of the employee(nullable)
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Email address of the employee
    /// </summary>
    public string? EmailId { get; set; }
}
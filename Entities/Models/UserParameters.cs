namespace Entities.Models;

public class UserParameters : QueryStringParameters
{
    public UserParameters()
    {
        OrderBy = "username";
    }

    public uint? Code { get; set; }
    public string? UserName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
}
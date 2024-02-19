namespace Entities.Models;

public class OwnerParameters : QueryStringParameters
{
    public OwnerParameters()
    {
        OrderBy = "name";
    }

    public string? Name { get; set; }
    public string? Address { get; set; }
}
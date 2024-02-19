namespace Entities.Models;

public class OwnerParameters : QueryStringParameters
{
    public OwnerParameters()
    {
        OrderBy = "name";
    }

    public uint? Code { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
}
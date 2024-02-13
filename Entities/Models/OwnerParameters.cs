namespace Entities.Models;

public class OwnerParameters : QueryStringParameters
{
    public OwnerParameters()
    {
        OrderBy = "name";
    }

    public uint MinYearBirth { get; set; }
    public uint MaxYearBirth { get; set; } = (uint)DateTime.Now.Year;

    public bool ValidYearRange => MaxYearBirth > MinYearBirth;

    public string? Name { get; set; }
}
namespace Entities.Models;

public class AccountParameters : QueryStringParameters
{
    public AccountParameters()
    {
        OrderBy = "code";
    }

    public uint? Code { get; set; }
    public string? AccountType { get; set; }
    public uint? OwnerCode { get; set; }
}
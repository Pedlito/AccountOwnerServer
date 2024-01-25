namespace Entities.DataTransferObjects;

public class AccountDto
{
    public int Code { get; set; }
    public required string AccountType { get; set; }
    public int OwnerCode { get; set; }
}
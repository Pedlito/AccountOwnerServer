namespace Entities.DataTransferObjects;

public class OwnerDto
{
    public int Code { get; set; }
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
}

public class OwnerAccountsDto
{
    public int Code { get; set; }
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }

    public IEnumerable<AccountDto> Accounts { get; set; } = [];
}
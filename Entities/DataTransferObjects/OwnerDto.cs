namespace Entities.DataTransferObjects;

public class OwnerDto : DatabaseBaseDto
{
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
}
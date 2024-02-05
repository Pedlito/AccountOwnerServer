using System.ComponentModel.DataAnnotations;

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

public class OwnerPostDto
{
    [Required(ErrorMessage = "El nombre del propietario es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    public required DateTime DateOfBirth { get; set; }

    [StringLength(150, ErrorMessage = "La dirección de no puede supierar los 150 caracteres")]
    public string? Address { get; set; }
}
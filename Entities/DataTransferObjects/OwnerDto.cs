using System.ComponentModel.DataAnnotations;
using AutoMapper.Configuration.Annotations;

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

    [StringLength(150, ErrorMessage = "La dirección no puede superar los 150 caracteres")]
    public string? Address { get; set; }
}

public class OwnerAccountPostDto
{
    [Required(ErrorMessage = "El tipo de cuenta es obligatorio")]
    [StringLength(50, ErrorMessage = "El tipo de cuenta no puede superar los 50 caracteres")]
    public required string AccountType { get; set; }
}

public class OwnerPostAccountsDto : OwnerPostDto
{
    [Required(ErrorMessage = "La lista de cuentas es obligatoria")]
    public required IEnumerable<OwnerAccountPostDto> Accounts { get; set; }
}

public class OwnerPutDto
{
    [Required(ErrorMessage = "El nombre del propietario es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
    public required DateTime DateOfBirth { get; set; }

    [StringLength(150, ErrorMessage = "La dirección no puede superar los 150 caracteres")]
    public string? Address { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public class AccountDto
{
    public int Code { get; set; }
    public required string AccountType { get; set; }
    public int OwnerCode { get; set; }
}

public class AccountPostDto
{
    [Required(ErrorMessage = "El tipo de cuenta es obligatorio")]
    [StringLength(50, ErrorMessage = "El tipo de cuenta no puede superar los 50 caracteres")]
    public required string AccountType { get; set; }

    [Required(ErrorMessage = "El código del propietario es obligatorio")]
    public required int OwnerCode { get; set; }
}

public class AccountPutDto
{
    [Required(ErrorMessage = "El tipo de cuenta es obligatorio")]
    [StringLength(50, ErrorMessage = "El tipo de cuenta no puede superar los 50 caracteres")]
    public required string AccountType { get; set; }

    [Required(ErrorMessage = "El código del propietario es obligatorio")]
    public required int OwnerCode { get; set; }
}
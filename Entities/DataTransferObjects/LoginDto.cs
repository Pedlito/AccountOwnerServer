using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects;

public class LoginPostDto
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre de usuario no puede superar los 50 caracteres")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "El password es obligatorio")]
    [StringLength(50, ErrorMessage = "El password no puede superar los 50 caracteres")]
    public required string Password { get; set; }
}
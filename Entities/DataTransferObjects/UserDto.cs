using System.ComponentModel.DataAnnotations;
using Npgsql.Replication;

namespace Entities.DataTransferObjects;

public class UserDto
{
    public int Code { get; set; }
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}

public class UserPostDto
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre de usuario no puede superar los 50 caracteres")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres")]
    public required string LastName { get; set; }
    
    [Required(ErrorMessage = "El password es obligatorio")]
    [StringLength(50, ErrorMessage = "El password no puede superar los 50 caracteres")]
    public required string Password { get; set; }

    [StringLength(50, ErrorMessage = "El correo no puede superar los 50 caracteres")]
    public required string Email { get; set; }
}

public class UserPutDto
{
    [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre de usuario no puede superar los 50 caracteres")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio")]
    [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres")]
    public required string LastName { get; set; }

    [StringLength(50, ErrorMessage = "El correo no puede superar los 50 caracteres")]
    public required string Email { get; set; }
}
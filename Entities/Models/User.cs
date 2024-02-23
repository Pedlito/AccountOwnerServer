using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models;

[EntityTypeConfiguration(typeof(UserEntityTypeConf))]
public class User : DatabaseBaseModel
{
    public int Code { get; set; }
    public required string UserName { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
}

public class UserEntityTypeConf : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user", "authentication");

        builder.HasKey(t => t.Code);

        builder.Property(t => t.Code)
            .HasColumnName("code").HasColumnType("smallint").UseIdentityColumn();

        builder.Property(t => t.FirstName)
            .HasColumnName("first_name").HasColumnType("varchar(50)").IsRequired();
        
        builder.Property(t => t.LastName)
            .HasColumnName("last_name").HasColumnType("varchar(50)").IsRequired();

        builder.Property(t => t.UserName)
            .HasColumnName("username").HasColumnType("varchar(50)").IsRequired();

        builder.Property(t => t.Password)
            .HasColumnName("password").HasColumnType("varchar(50)").IsRequired();
        
        builder.Property(t => t.Email)
            .HasColumnName("email").HasColumnType("varchar(50)");
    }
}
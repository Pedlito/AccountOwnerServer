using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models;

[EntityTypeConfiguration(typeof(OwnerEntityTypeConf))]
public class Owner : DatabaseBaseModel
{
    public Owner()
    {
        Accounts = new HashSet<Account>();
    }

    public int Code { get; set; }
    public required string Name { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }

    public virtual ICollection<Account> Accounts { get; set; }

    public void AppendAccount(Account account)
    {
        account.CreateDate = DateTime.Now;
        account.CreateUser = 10;
        account.IsEnable = true;
        this.Accounts.Add(account);
    }
}

public class OwnerEntityTypeConf : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("owner", "owner_acount");

        builder.HasKey(t => t.Code);
        
        builder.Property(t => t.Code)
            .HasColumnName("code").HasColumnType("smallint").UseIdentityColumn();
        
        builder.Property(t => t.Name)
            .HasColumnName("name").HasColumnType("varchar(50)").IsRequired();
        
        builder.Property(t => t.DateOfBirth)
            .HasColumnName("date_of_birth").HasColumnType("date").IsRequired();

        builder.Property(t => t.Address)
            .HasColumnName("address").HasColumnType("varchar(150)");
        
        builder.HasMany(t => t.Accounts).WithOne(t => t.Owner)
            .HasForeignKey(t => t.OwnerCode).HasPrincipalKey(t => t.Code);
    }
}
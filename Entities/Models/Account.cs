using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Models;

[EntityTypeConfiguration(typeof(AccountEntityTypeConf))]
public class Account : DatabaseBaseModel
{
    public int Code { get; set; }
    public required string AccountType { get; set; }
    public int OwnerCode { get; set; }

    public virtual Owner Owner { get; set; }   = null!;
}

public class AccountEntityTypeConf : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("acount", "owner_acount");

        builder.HasKey(t => t.Code);

        builder.Property(t => t.Code)
            .HasColumnName("code").HasColumnType("smallint").UseIdentityColumn();
        
        builder.Property(t => t.AccountType)
            .HasColumnName("account_type").HasColumnType("varchar(50)").IsRequired();

        builder.Property(t => t.OwnerCode)
            .HasColumnName("owner_code").HasColumnType("smallint").IsRequired();
    }
}
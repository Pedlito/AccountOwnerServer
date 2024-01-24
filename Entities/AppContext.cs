using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Owner> Owners { get; set; }   
    public DbSet<Account> Accounts{ get; set; }
}
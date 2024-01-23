using Microsoft.EntityFrameworkCore;

namespace Entities;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    
}
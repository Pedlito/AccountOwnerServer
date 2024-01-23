using Microsoft.EntityFrameworkCore;

namespace Entities;

public class AppContext(DbContextOptions options) : DbContext(options)
{
    
}
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Produto>? Produtos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
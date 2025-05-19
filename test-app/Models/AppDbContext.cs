using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test_app.Entities;

namespace test_app.Models;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<TokenInfo> TokenInfos { get; set; }
    public DbSet<Product> Products { get; set; }
}
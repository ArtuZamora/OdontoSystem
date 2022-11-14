using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OdontoSystem.Areas.Identity.Data;
using BusinessLogic.Models;

namespace OdontoSystem.Data;

public class OdontoSystemContext : IdentityDbContext<OdontoSystemUser>
{
    public OdontoSystemContext(DbContextOptions<OdontoSystemContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<BusinessLogic.Models.Inventory> Inventory { get; set; }
}

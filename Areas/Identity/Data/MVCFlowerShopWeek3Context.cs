using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCFlowerShopWeek3.Areas.Identity.Data;

namespace MVCFlowerShopWeek3.Data;

public class MVCFlowerShopWeek3Context : IdentityDbContext<MVCFlowerShopWeek3User>
{
    public MVCFlowerShopWeek3Context(DbContextOptions<MVCFlowerShopWeek3Context> options)
        : base(options)
    {
    }

    public DbSet<MVCFlowerShopWeek3.Models.Flower> FlowerTable { get; set; }   

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

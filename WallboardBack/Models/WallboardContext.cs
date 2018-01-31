using Microsoft.EntityFrameworkCore;

namespace WallboardBack.Models
{
    public class WallboardContext : DbContext, IWallboardContext
    {
        public WallboardContext(DbContextOptions<WallboardContext> options)
            : base(options)
        {
        }

        public DbSet<Widget> Widgets { get; set; }

    }
}
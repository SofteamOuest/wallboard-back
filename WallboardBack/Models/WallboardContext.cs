using Microsoft.EntityFrameworkCore;

namespace WallboardBack.Models
{
    public class WallboardContext : DbContext
    {
        public WallboardContext(): base()
        {
        }

        public WallboardContext(DbContextOptions<WallboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Widget> Widgets { get; set; }

    }
}
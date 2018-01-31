using Microsoft.EntityFrameworkCore;

namespace WallboardBack.Models
{
    public interface IWallboardContext
    {
        DbSet<Widget> Widgets { get; }

        int SaveChanges();
    }
}
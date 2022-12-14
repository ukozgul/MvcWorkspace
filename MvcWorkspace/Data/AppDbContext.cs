using Microsoft.EntityFrameworkCore;

namespace MvcWorkspace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        //DbSetler
    }
}

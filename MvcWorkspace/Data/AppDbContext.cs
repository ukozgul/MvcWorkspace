using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Models;

namespace MvcWorkspace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        //DbSetler 
        public DbSet<ToDoModel> ToDoModels { get; set; }   
    }
}

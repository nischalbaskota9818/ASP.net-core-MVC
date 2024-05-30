using Microsoft.EntityFrameworkCore;
using studentportal.web.Models.Entities;

namespace studentportal.web.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options) : base(Options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;

namespace StudentAPI.Data
{
    public class StdDbontext:DbContext
    {
        public StdDbontext(DbContextOptions<StdDbontext> options):base(options) { }
        public DbSet<Students> students { get; set; }
    }
}

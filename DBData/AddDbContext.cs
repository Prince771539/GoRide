using GoRide.Models;
using Microsoft.EntityFrameworkCore;

namespace GoRide.DBData
{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using MY_Website.Models.Domain;

namespace MY_Website.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserContact> Contacts { get; set; }
    }
}

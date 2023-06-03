using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hepra_testing_Mudblazor.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}

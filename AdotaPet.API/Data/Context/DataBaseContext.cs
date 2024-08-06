using AdotaPet.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AdotaPet.API.Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}

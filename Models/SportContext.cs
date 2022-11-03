using Exercices07.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exercices07.Models
{
    public class SportContext : DbContext
    {
        public virtual DbSet<Sport>?  Sports { get; set; }
        public virtual DbSet<Team>? Teams { get; set; }
        public virtual DbSet<Player>? Players { get; set; }
        public virtual DbSet<Trophy>? Trophies { get; set; }

        public SportContext()
        {

        }

        public SportContext(DbContextOptions<SportContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data
            modelBuilder.Entity<Sport>().HasData(
                    new Sport()
                    {
                        Id = 1,
                        Name = "Tennis"
                    },
                    new Sport()
                    {
                        Id=2,
                        Name = "Soccer"
                    }
                );
        }
    }
}

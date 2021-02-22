using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Context
{
    public class DomainContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonServices> PersonServices { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Menu> Menu { get; set; }

        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

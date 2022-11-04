using Microsoft.EntityFrameworkCore;
using Tickets.Data.Entities;

namespace Tickets.Data
{
    public class DataContext : DbContext
    {
   
        public DataContext (DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet <WorkType> WorkTypes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkType>().HasIndex(w => w.Descripcion).IsUnique();
        }

        public DbSet<Tickets.Data.Entities.ClienteType> ClienteType { get; set; }
    }
}

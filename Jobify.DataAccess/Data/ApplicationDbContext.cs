using Jobify.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobify.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Aplikimi> Aplikimet { get; set; }
        public DbSet<Punet> Punet { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Backend", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Frontend", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Full-Stack", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Punet>().HasData(
            new Punet { Id = 1, Name = "Punë 1", Description = "Përshkrimi 1", Kerkesat = "Kërkesat 1", Lokacioni = "Lokacioni 1",kategoria="Administrate",ImageUrl="" },
            new Punet { Id = 2, Name = "Punë 2", Description = "Përshkrimi 2", Kerkesat = "Kërkesat 2", Lokacioni = "Lokacioni 2",kategoria="Teknologji", ImageUrl = "" },
            new Punet { Id = 3, Name = "Punë 3", Description = "Përshkrimi 3", Kerkesat = "Kërkesat 3", Lokacioni = "Lokacioni 3",kategoria="Biznis", ImageUrl = "" }
    );


        }


         
              
    }
}

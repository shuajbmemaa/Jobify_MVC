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
        public DbSet<Puna> Punet { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Backend", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Frontend", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Full-Stack", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Puna>().HasData(
                new Puna
                {
                    Id = 1,
                    Emri_Pozites = "Full-Stack",
                    Pershkrimi = "edhe back edhe front",
                    Kerkesat = "Kerkesat1",
                    Lokacioni = "Prishtine",
                    ImageUrl = ""
                },
                new Puna
                {
                    Id = 2,
                    Emri_Pozites = "Administrata Nate",
                    Pershkrimi = "edhessss edhe front",
                    Kerkesat = "Kerkesat2",
                    Lokacioni = "Prishtine",
                    ImageUrl = ""
                },
                new Puna
                {
                    Id = 3,
                    Emri_Pozites = "Frontend",
                    Pershkrimi = "eddhe front",
                    Kerkesat = "Kerkesat3",
                    Lokacioni = "Vushtrri",
                    ImageUrl = ""
                },
                new Puna
                {
                    Id = 4,
                    Emri_Pozites = "Backend",
                    Pershkrimi = "edhe back ",
                    Kerkesat = "Kerkesat31",
                    Lokacioni = "Prishtine",
                    ImageUrl=""
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id=1,
                    Name="siu",
                    Pershkrimi="ssss",
                    Kerkesat="sssa",
                    PunaId=1
                },
                new Product
                {
                    Id = 2,
                    Name = "siau",
                    Pershkrimi = "sssfs",
                    Kerkesat = "sss2a",
                    PunaId = 1
                }
                );
        }
    }
}

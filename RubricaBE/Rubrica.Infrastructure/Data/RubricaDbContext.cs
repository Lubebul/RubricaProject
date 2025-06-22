using Microsoft.EntityFrameworkCore;
using Rubrica.Domain.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Infrastructure.Data
{
    public class RubricaDbContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<City> City { get; set; }

        public RubricaDbContext(DbContextOptions<RubricaDbContext> options) : base(options) { }

        //RubricaDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>(e =>
            {
                e.HasIndex(e => e.Name)
                .IsUnique();
            });

            #region initializing city values

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Milano" },
                new City { Id = 2, Name = "Roma" },
                new City { Id = 3, Name = "Napoli" },
                new City { Id = 4, Name = "Torino" },
                new City { Id = 5, Name = "Firenze" },
                new City { Id = 6, Name = "Venezia" },
                new City { Id = 7, Name = "Bologna" },
                new City { Id = 8, Name = "Genova" },
                new City { Id = 9, Name = "Palermo" },
                new City { Id = 10, Name = "Bari" },
                new City { Id = 11, Name = "Parigi" },
                new City { Id = 12, Name = "Londra" },
                new City { Id = 13, Name = "Madrid" },
                new City { Id = 14, Name = "Barcellona" },
                new City { Id = 15, Name = "Berlino" },
                new City { Id = 16, Name = "Monaco" },
                new City { Id = 17, Name = "Amsterdam" },
                new City { Id = 18, Name = "Vienna" },
                new City { Id = 19, Name = "Zurigo" },
                new City { Id = 20, Name = "Stoccolma" },
                new City { Id = 21, Name = "Copenhagen" },
                new City { Id = 22, Name = "Oslo" },
                new City { Id = 23, Name = "Helsinki" },
                new City { Id = 24, Name = "Dublino" },
                new City { Id = 25, Name = "Lisbona" },
                new City { Id = 26, Name = "Atene" },
                new City { Id = 27, Name = "Praga" },
                new City { Id = 28, Name = "Budapest" },
                new City { Id = 29, Name = "Varsavia" },
                new City { Id = 30, Name = "Mosca" },
                new City { Id = 31, Name = "Tokyo" },
                new City { Id = 32, Name = "Pechino" },
                new City { Id = 33, Name = "Shanghai" },
                new City { Id = 34, Name = "Seoul" },
                new City { Id = 35, Name = "Mumbai" },
                new City { Id = 36, Name = "Nuova Delhi" },
                new City { Id = 37, Name = "Bangkok" },
                new City { Id = 38, Name = "Singapore" },
                new City { Id = 39, Name = "Sydney" },
                new City { Id = 40, Name = "Melbourne" },
                new City { Id = 41, Name = "New York" },
                new City { Id = 42, Name = "Los Angeles" },
                new City { Id = 43, Name = "Chicago" },
                new City { Id = 44, Name = "San Francisco" },
                new City { Id = 45, Name = "Toronto" },
                new City { Id = 46, Name = "Vancouver" },
                new City { Id = 47, Name = "Città del Messico" },
                new City { Id = 48, Name = "San Paolo" },
                new City { Id = 49, Name = "Buenos Aires" },
                new City { Id = 50, Name = "Il Cairo" }
            );


            #endregion

            modelBuilder.Entity<Contact>(e =>
            {

                e.HasKey(x => x.Id);

                e.HasOne<City>()
                .WithMany()
                .HasPrincipalKey(x => x.Name)
                .HasForeignKey(x => x.City)
                .OnDelete(DeleteBehavior.Restrict); //configuro la proprietà Nome delle città come chiave esterna per Contact sulla property City

                e.Property(x => x.Name).IsRequired();
                e.Property(x => x.Surname).IsRequired();
                e.Property(x => x.Gender).IsRequired();
                e.Property(x => x.Email).IsRequired();
                e.HasIndex(x => new { x.Name, x.Surname }).IsUnique();

            });

        }


    }
}

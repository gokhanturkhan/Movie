using Microsoft.EntityFrameworkCore;
using Movie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Persistence.Context
{
    public class MovieDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Movie;Trusted_Connection = true");
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmSalon> FilmSalons { get; set; }
        public DbSet<Salon> Salons { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasMany(f => f.Salons).WithOne(s => s.Film).HasForeignKey(f => f.FilmId);
            modelBuilder.Entity<Salon>().HasMany(s => s.Films).WithOne(f => f.Salon).HasForeignKey(f => f.SalonId);
            modelBuilder.Entity<FilmSalon>().HasKey(s => new { s.SalonId, s.FilmId, s.ReleaseDate });
        }



    }
}

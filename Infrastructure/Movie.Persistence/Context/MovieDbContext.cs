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
        public DbSet<Salon> Salons { get; set; }
  

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieUI.Models
{
    public class FilmsViewModel
    {
        public List<Movie.Domain.Entities.Film> Films { get; set; }
        public List<Movie.Domain.Entities.Salon> Salons { get; set; }
        public string BaslangicDate { get; set; }
        public string BitisDate { get; set; }
    }
}

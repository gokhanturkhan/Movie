using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieUI.Models
{
    public class ReleaseFilmViewModel
    {
        public List<Movie.Application.Dto.FilmSalonDto> FilmSalonDtos { get; set; }
        public Movie.Domain.Entities.Salon Salon { get; set; }
    }
}

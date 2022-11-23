using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieUI.Models
{
    public class ReleaseSalonViewModel
    {
        public List<Movie.Application.Dto.FilmSalonDto> FilmSalonDtos { get; set; }
        public Movie.Domain.Entities.Film Film { get; set; }
    }
}

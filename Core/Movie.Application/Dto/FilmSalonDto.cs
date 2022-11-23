using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Dto
{
    public class FilmSalonDto
    {
        public int FilmId { get; set; }
        public int SalonId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string FilmName { get; set; }
        public string SalonName { get; set; }
    }
}

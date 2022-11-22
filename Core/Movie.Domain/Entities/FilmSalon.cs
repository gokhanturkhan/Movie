using Movie.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class FilmSalon : BaseEntity
    {
        public int FilmId { get; set; }
        public int SalonId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

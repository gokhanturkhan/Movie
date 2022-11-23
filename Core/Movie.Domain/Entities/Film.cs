using Movie.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Film : BaseEntity
    {
        public string Name { get; set; }
        public DateTime? YearOfConstruction { get; set; }

        public ICollection<FilmSalon> Salons { get; set; }
}
}

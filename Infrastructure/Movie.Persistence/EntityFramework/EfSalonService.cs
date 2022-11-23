using Movie.Application.Dto;
using Movie.Application.Interfaces.Repository;
using Movie.Domain.Entities;
using Movie.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Persistence.EntityFramework
{
    public class EfSalonService : EfEntityRepositoryBase<Salon,MovieDbContext>, ISalonService
    {

        public List<FilmSalonDto> GetFilmsBySalon(int SalonId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from f in context.Films
                             join fs in context.FilmSalons
                             on f.Id equals fs.FilmId
                             where fs.SalonId == SalonId
                             select new FilmSalonDto
                             {
                                 FilmName = f.Name,
                                 ReleaseDate = fs.ReleaseDate,
                                 SalonId = fs.SalonId,
                             };

                return result.ToList();
            }
         
        }

    }
}

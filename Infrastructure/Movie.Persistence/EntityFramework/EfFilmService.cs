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
    public class EfFilmService : EfEntityRepositoryBase<Film, MovieDbContext>, IFilmService
    {

        public void AddFilmToSalon(Film film, Salon salon, DateTime releaseDate)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                context.FilmSalons.Add(new FilmSalon
                {
                    FilmId = film.Id,
                    SalonId = salon.Id,
                    ReleaseDate = releaseDate
                });
                context.SaveChanges();
            }
        }

        public List<FilmSalonDto> GetSalonsByFilmId(int FilmId)
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from s in context.Salons
                             join fs in context.FilmSalons
                             on s.Id equals fs.SalonId
                             where fs.FilmId == FilmId
                             select new FilmSalonDto
                             {
                                 SalonName = s.Name,
                                 ReleaseDate = fs.ReleaseDate,
                                 SalonId = fs.SalonId,
                                 FilmId = fs.FilmId
                             };

                return result.ToList();
            }

        }
    }
}

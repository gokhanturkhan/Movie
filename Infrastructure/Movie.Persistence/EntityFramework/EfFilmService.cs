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
    public class EfFilmService : EfEntityRepositoryBase<Film,MovieDbContext>, IFilmService
    {

    }
}

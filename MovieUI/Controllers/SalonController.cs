using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Application.Interfaces.Repository;
using Movie.Persistence.EntityFramework;
using MovieUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieUI.Controllers
{
    [Authorize]
    public class SalonController : Controller
    {

        public readonly ISalonService _salonService;
        public readonly IFilmService _filmService;

        public SalonController(IFilmService filmService, ISalonService salonService)
        {
            _filmService = filmService;
            _salonService = salonService;
        }
        public IActionResult Index()
        {
            var salons = _salonService.GetAll();
            return View(salons);
        }

        public IActionResult ReleaseFilms(int SalonId)
        {
            var model = new ReleaseFilmViewModel();
            model.FilmSalonDtos = ((EfSalonService)_salonService).GetFilmsBySalon(SalonId);
            model.Salon = _salonService.Get(a => a.Id == SalonId);
            
            return View(model);
        }


        
    }
}

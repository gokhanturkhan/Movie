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
    public class FilmController : Controller
    {
        public readonly ISalonService _salonService;
        public readonly IFilmService _filmService;

        public FilmController(IFilmService filmService, ISalonService salonService)
        {
            _filmService = filmService;
            _salonService = salonService;
        }
        public IActionResult Index(DateTime baslangic, DateTime bitis)
        {
            var model = new FilmsViewModel();

            model.Salons = _salonService.GetAll();

            if(baslangic != DateTime.MinValue && bitis != DateTime.MinValue)
            {
                model.BaslangicDate = baslangic.ToString("yyyy-MM-dd");
                model.BitisDate = bitis.ToString("yyyy-MM-dd");
                //ViewBag.baslangictarih = baslangic.ToString("yyyy-MM-dd");
                //ViewBag.bitistarih = bitis.ToString("yyyy-MM-dd");
                model.Films = _filmService.GetAll(a => a.YearOfConstruction >= baslangic && a.YearOfConstruction <= bitis);
              
            }
            else
            {
                model.Films = _filmService.GetAll();
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult AddFilm()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Movie.Domain.Entities.Film film)
        {
            _filmService.Add(film);
           
           
            return RedirectToAction("Index", "Film");
        }

        [HttpPost]
        public IActionResult AddFilmRelease(int FilmId,DateTime ReleaseDate, int SalonId)
        {
            ((EfFilmService)_filmService).AddFilmToSalon(_filmService.Get(a => a.Id == FilmId), new Movie.Domain.Entities.Salon { Id = SalonId }, ReleaseDate);

            return RedirectToAction("Index", "Film");
        }

        public IActionResult DeleteFilm(int modelid)
        {
            _filmService.Delete(_filmService.Get(a => a.Id == modelid));
            
            return RedirectToAction("Index", "Film");
        }

        public IActionResult UpdateFilmPartial(int Id)
        {
            var model = _filmService.Get(a => a.Id == Id);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult UpdateFilm(Movie.Domain.Entities.Film film)
        {
            _filmService.Update(film);

            return RedirectToAction("Index", "Film");
        }
        public IActionResult ReleaseSalons(int FilmId)
        {
            var model = new ReleaseSalonViewModel();
            model.FilmSalonDtos = ((EfFilmService)_filmService).GetSalonsByFilmId(FilmId);
            model.Film = _filmService.Get(a => a.Id == FilmId);
            return View(model);
        }
        
    }
}

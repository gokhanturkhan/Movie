using Microsoft.AspNetCore.Mvc;
using Movie.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieUI.Controllers
{
    public class FilmController : Controller
    {
        public readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        public IActionResult Index(DateTime baslangic, DateTime bitis)
        {
            if(baslangic != DateTime.MinValue && bitis != DateTime.MinValue)
            {
                ViewBag.baslangictarih = baslangic.ToString("yyyy-MM-dd");
                ViewBag.bitistarih = bitis.ToString("yyyy-MM-dd");
                return View(_filmService.GetAll(a => a.YearOfConstruction >= baslangic && a.YearOfConstruction <= bitis));
            }

            return View(_filmService.GetAll());
        }

        [HttpGet]
        public IActionResult AddFilm()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Movie.Domain.Entities.Film film)
        {
            film.CreatedDate = DateTime.Now;
            _filmService.Add(film);
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
    }
}

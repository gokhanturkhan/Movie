using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie.Application.Interfaces.Repository;
using MovieUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly ISalonService _salonService;
        public HomeController(IFilmService filmService, ISalonService salonService)
        {
            _filmService = filmService;
            _salonService = salonService;
        }

        public IActionResult Index()
        {

            //var filmler = _filmService.GetAll(a => a.Id == 2);
            var salonlar = _salonService.GetAll();
            return View(salonlar);
        }

    }
}

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

        public HomeController(IFilmService filmService)
        {
            _filmService = filmService;
        }


        public IActionResult Index()
        {
            var filmler = _filmService.GetAll(a => a.Id== 2);
            return View(filmler);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

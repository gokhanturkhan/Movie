using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            return RedirectToAction("Index", "Film");
        }

    }
}

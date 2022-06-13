using informatica_fstival.Database;
using informatica_fstival.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace informatica_fstival.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            // lijst met producten ophalen
            var films = GetAllFilms();

            // de lijst met producten in de html stoppen
            return View(films.Take(6).ToList());
        }

        public List<Film> GetAllFilms()
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows("select * from film");

            // lijst maken om alle producten in te stoppen
            List<Film> films = new List<Film>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                Film f = new Film();
                f.Titel = row["naam"].ToString();
                f.Poster = row["poster"].ToString();
                f.Cast = row["cast"].ToString();
                f.Speelduur = row["speelduur"].ToString();
                f.Id = Convert.ToInt32(row["id"]);

                // en dat product voegen we toe aan de lijst met producten
                films.Add(f);
            }

            return films;
        }

        public Film GetFilm(int id)
        {
            // alle producten ophalen uit de database
            var rows = DatabaseConnector.GetRows($"select * from film_uitzending inner join film on film_uitzending.film_id = film.id where film_id = {id}");

            // lijst maken om alle producten in te stoppen
            List<Film> films = new List<Film>();

            foreach (var row in rows)
            {
                // Voor elke rij maken we nu een product
                Film f = new Film();
                f.Titel = row["naam"].ToString();
                f.Beschrijving = row["beschrijving"].ToString();
                f.Regisseur = row["regisseur"].ToString();
                f.Cast = row["cast"].ToString();
                f.Poster = row["poster"].ToString();
                f.Beschikbaarheid = Convert.ToInt32(row["beschikbaarheid"]);
                f.Start = row["start"].ToString();
                f.Eind = row["eind"].ToString();
                f.Id = Convert.ToInt32(row["id"]);

                // en dat product voegen we toe aan de lijst met producten
                films.Add(f);
            }

            return films[0];
        }


        [Route("show-all")]
        public IActionResult ShowAll()
        {
            return View();
        }
        [Route("contact")]
       
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("contact")]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
                DatabaseConnector.SavePerson(person);
                return Redirect("/Succes");
            return View(person);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("Succes")]
        public IActionResult Succes()
        {
            return View();
        }

        [Route("film/{id}")]
        public IActionResult FilmDetails(int id)
        {
            var film = GetFilm(id);

            return View(film);

        }
        [Route("overzicht")]
        public IActionResult AllFilms()
        {
            var films = GetAllFilms();

            return View(films);
        }
    }
}

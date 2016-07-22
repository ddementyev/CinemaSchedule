using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaSchedule.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaDb _cinemaDb;

        public CinemaController(CinemaDb cinemaDb)
        {
            _cinemaDb = cinemaDb;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetSchedule(CinemaData data)
        {
            var movies = _cinemaDb.Sessions.Where(a => a.Date == data.DateTime).GroupBy(t => t.Theater).ToList();

            data.Cinema = new List<TheaterData>();


            foreach (var group in movies)
            {
                data.Cinema.Add(new TheaterData()
                {
                    Theater = group.Key,
                    Movies = new List<MovieData>()
                    {
                        new MovieData()
                        {
                            MovieTitle = group.Select(a=>a.Movie).FirstOrDefault(),
                            MovieSessions = group.Select(a=>a.Time).ToList()
                        }
                    }
                    // MoviesTitles = group.ToList().GroupBy(a => a.Movie).ToList(),

                });
            }
            //  = _cinemaDb.Sessions.Where(a => a.Date == data.DateTime).ToList();

            return View("List", data);
        }
    }
}
using CinemaSchedule.Models;
using Newtonsoft.Json;
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


            data.Cinema = BuildTheaterData(movies);


            //  = _cinemaDb.Sessions.Where(a => a.Date == data.DateTime).ToList();

            return View("List", data);
        }

        public ActionResult AddMovie(BigViewModel cat)
        {
            var model = new BigViewModel();
            if (cat.SelectedDataModel != null)
            {
                var session = new Sessions()
                {
                    Theater = cat.SelectedDataModel.SelectedTheater,
                    Movie = cat.SelectedDataModel.SelectedMovie,
                    Date = cat.SelectedDataModel.Date,
                    Time = cat.SelectedDataModel.Time
                };

                _cinemaDb.Sessions.Add(session);
                _cinemaDb.SaveChanges();
                return View("List");
            }
            model.CinemaCatalogModel = new CinemaCatalogModel()
            {
                Theaters = _cinemaDb.Theaters.ToList(),
                Movies = _cinemaDb.Movies.ToList(),
            };

            return View(model);
        }

        public ActionResult EditMovie(string session)
        {
            var res = JsonConvert.DeserializeObject<BaseData>(session);

            return View(res);
        }

        public ActionResult DeleteMovie(BaseData session)
        {
           var data = new CinemaData();
            //var movies = _cinemaDb.Sessions.Where(a => a.Theater == session.Theater && a.Movie == session.Movie && a.Date == session.Date).GroupBy(a => a.Theater).ToList();
            //data.Cinema = BuildTheaterData(movies);
            //data.DateTime = session.Date;
            return View(data);
        }

        public List<TheaterData> BuildTheaterData(List<IGrouping<string, Sessions>> movies)
        {
            var data = new List<TheaterData>();
            foreach (var group in movies)
            {
                var movs = new List<MovieData>();
                var groupMovies = group.Select(a => a.Movie).Distinct();

                foreach (var g in groupMovies)
                {
                    movs.Add(new MovieData()
                    {
                        MovieTitle = g,
                        MovieSessions = group.Where(b => b.Movie == g).Select(a => a.Time.ToString()).ToList()
                    });
                }

                data.Add(new TheaterData()
                {
                    Theater = group.Key,
                    Movies = movs

                });
            }
            return data;
        }
    }
}
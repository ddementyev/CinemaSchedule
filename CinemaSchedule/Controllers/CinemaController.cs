using AutoMapper;
using CinemaSchedule.App_Start;
using CinemaSchedule.Interfaces;
using CinemaSchedule.Models;
using CinemaSchedule.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaSchedule.Controllers
{
    public class CinemaController : Controller
    {
        private readonly CinemaDbModel _cinemaDb;
        private readonly ICinemaService _cinemaService;
        private readonly IScheduleService _scheduleService;

        public CinemaController(CinemaDbModel cinemaDb, ICinemaService cinemaService, IScheduleService scheduleService)
        {
            _cinemaDb = cinemaDb;
            _cinemaService = cinemaService;
            _scheduleService = scheduleService;
        }

        public ActionResult Sessions(Cinema cinema)
        {
            //if (ModelState.IsValid)
            //{
                var sessions = _cinemaDb.Sessions.Where(d => d.Date == cinema.DateTime).GroupBy(t => t.Theater).ToList();
                cinema.Schedule = _scheduleService.MakeSchedule(sessions);
           // }
            return View(cinema);
        }

        public ActionResult AddSession(SessionModel model)
        {
            //var model = new SessionModel();
            if (model.Session != null && ModelState.IsValid)
            {
                _cinemaService.EditSession(model.Session, ActionType.AddSession);
                return View("Sessions");
            }

            model.CinemaCatalog = new CinemaCatalog()
            {
                Theaters = _cinemaDb.Theaters.ToList(),
                Movies = _cinemaDb.Movies.ToList(),
            };

            return View(model);
        }

        public ActionResult EditSession(string session)
        {
            var res = JsonConvert.DeserializeObject<CinemaSchedule.Models.Sessions>(session);
            return View(res);
        }

        public ActionResult DeleteSession(CinemaSchedule.Models.Sessions session)
        {
            IMapper Mapper = MappingConfig.MapperConfiguration.CreateMapper();
            var dest = Mapper.Map<Session>(session);
            _cinemaService.EditSession(dest, ActionType.DeleteSession);

            return View("Sessions");
        }
    }
}
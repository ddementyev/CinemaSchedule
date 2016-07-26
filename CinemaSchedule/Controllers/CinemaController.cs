using AutoMapper;
using CinemaSchedule.Interfaces;
using CinemaSchedule.Models;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace CinemaSchedule.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IScheduleService _scheduleService;

        public CinemaController(ICinemaService cinemaService, IScheduleService scheduleService)
        {
            _cinemaService = cinemaService;
            _scheduleService = scheduleService;
        }

        public ActionResult Sessions(Cinema cinema)
        {
            cinema.Schedule = _scheduleService.MakeSchedule(cinema.DateTime);
            return View(cinema);
        }

        public ActionResult AddSession(SessionModel model)
        {
            if (model.Session != null && ModelState.IsValid)
            {
                var isSessionExist = _cinemaService.CheckSession(model.Session);

                if (!isSessionExist)
                {
                    _cinemaService.EditSession(model.Session, ActionType.AddSession);
                    return View("Sessions", new Cinema() { Schedule = _scheduleService.MakeSchedule(DateTime.Parse(model.Session.Date)) });
                }
                else
                {
                    ModelState.AddModelError("SameSession", "Ошибка: несколько одинаковых сеансов");
                }
            }

            model.CinemaCatalog = _cinemaService.GetCatalog();
            return View(model);
        }

        public ActionResult EditSession(string session)
        {
            if (session == null)
            {
                ModelState.AddModelError("NoSession", "Отсутствует сеанс для редактирования");
                return View();
            }
            else return View(JsonConvert.DeserializeObject<AllSessions>(session));
        }

        public ActionResult DeleteSession(AllSessions session)
        {
            var sessionToEdit = Mapper.Map<AllSessions, Session>(session);
            _cinemaService.EditSession(sessionToEdit, ActionType.DeleteSession);

            return View("Sessions", new Cinema() { Schedule = _scheduleService.MakeSchedule(DateTime.Parse(session.Date)) });
        }
    }
}
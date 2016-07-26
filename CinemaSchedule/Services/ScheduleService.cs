using CinemaSchedule.Interfaces;
using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaSchedule.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ICinemaService _cinemaService;

        public ScheduleService(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public List<Schedule> MakeSchedule(DateTime date)
        {
            var sessions = _cinemaService.GetSessions(date);
            var schedule = new List<Schedule>();

            foreach (var session in sessions)
            {
                var movies = new List<Movie>();

                foreach (var movie in session.Select(m => m.Movie).Distinct())
                {
                    movies.Add(new Movie()
                    {
                        Title = movie,
                        Sessions = session.Where(m => m.Movie == movie).Select(t => t.Time.ToString()).ToList()
                    });
                }

                schedule.Add(new Schedule()
                {
                    Theater = session.Key,
                    Movies = movies
                });
            }

            return schedule;
        }
    }
}
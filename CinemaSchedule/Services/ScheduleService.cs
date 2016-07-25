using CinemaSchedule.Interfaces;
using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaSchedule.Services
{
    public class ScheduleService : IScheduleService
    {
        public List<Schedule> MakeSchedule(List<IGrouping<string, Sessions>> sesions)
        {
            var schedule = new List<Schedule>();
            foreach (var session in sesions)
            {
                var movies = new List<Movie>();

                foreach (var movie in session.Select(a => a.Movie).Distinct())
                {
                    movies.Add(new Movie()
                    {
                        Title = movie,
                        Sessions = session.Where(b => b.Movie == movie).Select(a => a.Time.ToString()).ToList()
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
using CinemaSchedule.Models;
using System;
using System.Collections.Generic;

namespace CinemaSchedule.Interfaces
{
    public interface IScheduleService
    {
        List<Schedule> MakeSchedule(DateTime date);
    }
}
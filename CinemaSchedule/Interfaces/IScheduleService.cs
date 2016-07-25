using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaSchedule.Interfaces
{
    public interface IScheduleService
    {
        List<Schedule> MakeSchedule(List<IGrouping<string, Sessions>> sesions);
    }
}
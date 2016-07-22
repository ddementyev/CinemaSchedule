using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaSchedule.Models
{
    public class CinemaData
    {
        public DateTime DateTime { get; set; }
        public List<TheaterData> Cinema { get; set; }
    }

    public class TheaterData
    {
        public string Theater { get; set; }
        public List<MovieData> Movies { get; set; }

    }

    public class MovieData
    {
        public string MovieTitle { get; set; }
        public List<TimeSpan> MovieSessions { get; set; }
    }
}
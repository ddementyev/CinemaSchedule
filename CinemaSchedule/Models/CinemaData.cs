using Newtonsoft.Json;
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

    public class BaseData
    {
        [JsonProperty("Theater")]
        public string Theater { get; set; }
        [JsonProperty("MovieData")]
        public MovieData MovieData { get; set; }
        [JsonProperty("SelectedSession")]
        public string SelectedSession { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }
    }

    public class TheaterData
    {
   
        [JsonProperty("Theater")]
        public string Theater { get; set; }
        [JsonProperty("Movies")]
        public List<MovieData> Movies { get; set; }

    }

    public class MovieData
    {
        [JsonProperty("MovieTitle")]
        public string MovieTitle { get; set; }
        [JsonProperty("MovieSessions")]
        public List<string> MovieSessions { get; set; }
    }
}
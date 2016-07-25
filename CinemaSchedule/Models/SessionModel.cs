using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaSchedule.Models
{
    public class SessionModel
    {
        public Session Session { get; set; }
        public CinemaCatalog CinemaCatalog { get; set; }
    }

    public class BaseSession
    {
        public string Theater { get; set; }      
        public string Date { get; set; }
        public string Time { get; set; }
    }

    public class Session : BaseSession
    {     
        public string Movie { get; set; }
    }

    public class Sessions : BaseSession
    {
        public Movie Movie { get; set; }
    }

    public class CinemaCatalog
    {
        public List<Movies> Movies { get; set; }
        public List<Theaters> Theaters { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaSchedule.Models
{

    public class BigViewModel
    {
        public SelectedDataModel SelectedDataModel { get; set; }
        public CinemaCatalogModel CinemaCatalogModel { get; set; }
    }

    public class SelectedDataModel
    {

        public string SelectedMovie { get; set; }
        public string SelectedTheater { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }

    public class CinemaCatalogModel
    {
        public List<Movies> Movies { get; set; }
        public List<Theaters> Theaters { get; set; }

    }
}
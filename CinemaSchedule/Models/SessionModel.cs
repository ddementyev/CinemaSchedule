using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public class BaseSession : IValidatableObject
    {
        [Required(ErrorMessage = "Выберите кинотеатр")]
        public string Theater { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Введите дату")]
        public string Date { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Введите время сеанса")]
        public string Time { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTime.Parse(Date ?? DateTime.Now.Date.ToString()).Date < DateTime.Now.Date)
            {
                yield return new ValidationResult("Выбранная дата не может быть раньше текущей", new[] { "Date" });
            }
        }
    }

    public class Session : BaseSession
    {
        [Required(ErrorMessage = "Выберите фильм")]
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
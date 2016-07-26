using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CinemaSchedule.Models
{
    public class Cinema : IValidatableObject
    {
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Введите дату")]
        public DateTime DateTime { get; set; }

        public List<Schedule> Schedule { get; set; }
        public Cinema()
        {
            DateTime = DateTime.Now.Date;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateTime.Date < DateTime.Now.Date)
            {
                yield return new ValidationResult("Выбранная дата не может быть раньше текущей", new[] { "DateTime" });
            }
        }
    }

    public class Schedule
    {
        [JsonProperty("Theater")]
        public string Theater { get; set; }
        [JsonProperty("Movies")]
        public List<Movie> Movies { get; set; }
    }

    public class Movie
    {
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Sessions")]
        public List<string> Sessions { get; set; }
    }
}
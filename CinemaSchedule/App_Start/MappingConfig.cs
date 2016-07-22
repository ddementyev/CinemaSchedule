using AutoMapper;
using CinemaSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaSchedule.App_Start
{
    public class MappingConfig
    {
        public static void ConfigureMapping()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Sessions, TheaterData>()
                .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Theater));
               // .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => ));
            });
        }
    }
}
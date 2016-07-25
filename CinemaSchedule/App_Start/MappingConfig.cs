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
        public static MapperConfiguration MapperConfiguration;

        public static void RegisterMappings()
        {

            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<SelectedDataModel, BaseData>()
                //.ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.SelectedTheater))
                //.ForMember(dest => dest.MovieData.MovieTitle, opt => opt.MapFrom(src => src.SelectedMovie))
                //.ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                //.ForMember(dest => dest.SelectedSession, opt => opt.MapFrom(src => src.Time));

                cfg.CreateMap<CinemaSchedule.Models.Sessions, Session>()
                  .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Theater))
                  .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                  .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                  .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));

            });
        }
    }
}
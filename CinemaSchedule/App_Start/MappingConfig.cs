using AutoMapper;
using CinemaSchedule.Models;

namespace CinemaSchedule.App_Start
{
    public class MappingConfig
    {

        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AllSessions, Session>()
                  .ForMember(dest => dest.Theater, opt => opt.MapFrom(src => src.Theater))
                  .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Title))
                  .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                  .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));

            });
        }
    }
}
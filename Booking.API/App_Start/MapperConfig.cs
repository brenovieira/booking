using AutoMapper;
using Booking.API.Dto;

namespace Booking.API
{
    public class MapperConfig
    {
        public static void Register()
        {
            // https://github.com/AutoMapper/AutoMapper/wiki/Configuration
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DAL.Entities.Person, Person>();
                cfg.CreateMap<DAL.Entities.Availability, Availability>();
                cfg.CreateMap<DAL.Entities.Event, Event>();
                cfg.CreateMap<DAL.Entities.HealthIssue, HealthIssue>();
                cfg.CreateMap<DAL.Entities.Order, Order>();

                cfg.CreateMap<Person, DAL.Entities.Person>();
                cfg.CreateMap<Availability, DAL.Entities.Availability>();
                cfg.CreateMap<Event, DAL.Entities.Event>();
                cfg.CreateMap<HealthIssue, DAL.Entities.HealthIssue>();
                cfg.CreateMap<Order, DAL.Entities.Order>();
            });
        }
    }

    public static class DTOExtensions
    {
        public static V To<T, V>(this T entity)
        {
            if (entity == null) return default(V);
            return Mapper.Map<T, V>(entity);
        }
    }
}
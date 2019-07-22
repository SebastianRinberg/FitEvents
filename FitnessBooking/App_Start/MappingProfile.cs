using AutoMapper;
using FitnessBooking.Dtos;
using FitnessBooking.Models;

namespace FitnessBooking.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<EventType, EventTypeDto>();
            CreateMap<Event, EventDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}
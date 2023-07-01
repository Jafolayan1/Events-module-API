using AutoMapper;

using Entities.DataTransferObjects;
using Entities.Models;

namespace Events_module_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventDto>();

            CreateMap<CreateEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
        }
    }
}
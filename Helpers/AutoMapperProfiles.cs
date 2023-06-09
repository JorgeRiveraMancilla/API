using API.DTOs.PrimeraPeticion;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<AppReserve, ReserveDto>();
            CreateMap<AppBook, BookDto>();
        }  
    }
}
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, DTOs.FirstRequest.UserDto>();
            CreateMap<AppReserve, DTOs.FirstRequest.ReserveDto>();
            CreateMap<AppBook, DTOs.FirstRequest.BookDto>();

            CreateMap<AppBook, DTOs.SecondRequest.BookDto>();
            CreateMap<AppReserve, DTOs.SecondRequest.ReserveDto>();
            CreateMap<AppUser, DTOs.SecondRequest.UserDto>();
        }  
    }
}
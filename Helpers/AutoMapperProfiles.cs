using AutoMapper;
using DotnetWebAPI.Models;
using DotnetWebAPI.Models.DTOs;

namespace DotnetWebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DriverCreateDto, Driver>();
        }
    }
}
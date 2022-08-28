using AutoMapper;
using TestbART.Dtos;
using TestbART.Model;

namespace TestbART.Profiles
{
    public class IncidentProfile : Profile
    {
        public IncidentProfile()
        {
            CreateMap<IncidentCreateDto, Incident>();
        }
    }
}

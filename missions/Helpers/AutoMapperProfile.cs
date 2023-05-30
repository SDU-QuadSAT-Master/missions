

using missions.Controllers;
using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<MissionCreateRequest, Mission>();
        CreateMap<MissionUpdateRequest, Mission>();

        CreateMap<AntennaConfigCreateRequest, AntennaConfig>();
        CreateMap<AntennaConfigCreateRequest, AntennaConfig>();
    }
}
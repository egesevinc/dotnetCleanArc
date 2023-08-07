using AutoMapper;

namespace Dot7.CleanArchitecture.Application.Beach.UpdateBeach;
public class UpdateBeachMapper : Profile
{
    public UpdateBeachMapper()
    {
        CreateMap<UpdateBeachRequest, Dot7.CleanArchitecture.Domain.Entities.Beach>();
    }
}
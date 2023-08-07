using AutoMapper;

namespace Dot7.CleanArchitecture.Application.Beach.CreateBeach;
public class CreateBeachMapper : Profile
{
    public CreateBeachMapper()
    {
        CreateMap<CreateBeachRequest, Dot7.CleanArchitecture.Domain.Entities.Beach>();
    }

}
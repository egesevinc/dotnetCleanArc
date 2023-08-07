using AutoMapper;

namespace Dot7.CleanArchitecture.Application.Beach.DeleteBeach;
public class DeleteBeachMapper : Profile
{
    public DeleteBeachMapper()
    {
        CreateMap<DeleteBeachRequest, Dot7.CleanArchitecture.Domain.Entities.Beach>();
    }
    
}
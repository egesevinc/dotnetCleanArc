using AutoMapper;

namespace Dot7.CleanArchitecture.Application.Beach.GetAllBeaches;
public class GetAllBeachesMapper:Profile
{
public GetAllBeachesMapper()
{
    CreateMap<Dot7.CleanArchitecture.Domain.Entities.Beach,GetAllBeachesResponse>();
}
}
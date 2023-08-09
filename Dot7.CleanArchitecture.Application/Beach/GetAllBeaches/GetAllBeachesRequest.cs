using MediatR;

namespace Dot7.CleanArchitecture.Application.Beach.GetAllBeaches;
public class GetAllBeachesRequest : IRequest<GetAllBeachesResponseWithCount>
{
    public int PageNumber { get; set; } = 1; // Default to page 1 if not specified
    public int PageSize { get; set; } = 10; // Default page size if not specified
    public string? Place { get; set; }
    public string? BeachName { get; set; }
   
}
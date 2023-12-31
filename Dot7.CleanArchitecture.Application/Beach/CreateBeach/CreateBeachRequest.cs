using MediatR;

namespace Dot7.CleanArchitecture.Application.Beach.CreateBeach;
public class CreateBeachRequest:IRequest<int>
{
    public string? BeachName { get; set; }
    public string? Place { get; set; }
    public string? ImageUrl { get; set; }
}
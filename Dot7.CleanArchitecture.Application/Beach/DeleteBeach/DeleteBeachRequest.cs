using MediatR;

namespace Dot7.CleanArchitecture.Application.Beach.DeleteBeach;
public class DeleteBeachRequest:IRequest<int>
{
    public string? BeachName { get; set; }
}
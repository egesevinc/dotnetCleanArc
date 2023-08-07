using MediatR;

namespace Dot7.CleanArchitecture.Application.Beach.UpdateBeach;
public class UpdateBeachRequest : IRequest<int>
{
    public int Id { get; set; }
    public string? BeachName { get; set; }
    public string? Place { get; set; }
    public string? ImageUrl { get; set; }
}
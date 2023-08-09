namespace Dot7.CleanArchitecture.Application.Beach.GetAllBeaches;
public class GetAllBeachesResponse
{

    public int Id { get; set; }
    public string? BeachName { get; set; }
    public string? Place { get; set; }
    public string? ImageUrl { get; set; }
    

}

public class GetAllBeachesResponseWithCount
{
    public List<GetAllBeachesResponse> Beaches { get; set; }
    public int TotalCount { get; set; }
}
using AutoMapper;
using Dot7.CleanArchitecture.Application.Context;
using MediatR;

namespace Dot7.CleanArchitecture.Application.Beach.CreateBeach;
public class CreateBeachCommandHandler : IRequestHandler<CreateBeachRequest, int>
{
    private readonly IMyWorldDbContext _myWorldDbContext;
    private readonly IMapper _mapper;
    public CreateBeachCommandHandler(IMyWorldDbContext myWorldDbContext, IMapper mapper)
    {
        _myWorldDbContext = myWorldDbContext;
        _mapper = mapper;
        
    }
    public async Task<int> Handle(CreateBeachRequest request, CancellationToken cancellationToken)
    {
       var newBeach = _mapper.Map<Dot7.CleanArchitecture.Domain.Entities.Beach>(request);
       _myWorldDbContext.Beach.Add(newBeach);
       await _myWorldDbContext.SaveToDbAsync();
       return newBeach.Id;
    }
}
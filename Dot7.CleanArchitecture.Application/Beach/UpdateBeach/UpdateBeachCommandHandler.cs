using AutoMapper;
using Dot7.CleanArchitecture.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dot7.CleanArchitecture.Application.Beach.UpdateBeach;
public class UpdateBeachCommandHandler : IRequestHandler<UpdateBeachRequest, int>
{
    private readonly IMyWorldDbContext _myWorldDbContext;
    private readonly IMapper _mapper;

    public UpdateBeachCommandHandler(IMyWorldDbContext myWorldDbContext, IMapper mapper)
    {
        _myWorldDbContext = myWorldDbContext;
        _mapper = mapper;
    }

    public async Task<int> Handle(UpdateBeachRequest request, CancellationToken cancellationToken)
    {
        var existingBeach = await _myWorldDbContext.Beach.FirstOrDefaultAsync(b => b.Id == request.Id);

        if (existingBeach == null)
        {
            throw new InvalidOperationException("Beach not found");
        }

        // Update the properties of the existing beach with the new values
        existingBeach.BeachName = request.BeachName;
        existingBeach.Place = request.Place; // Update other properties similarly
        existingBeach.ImageUrl = request.ImageUrl;
        // Optionally, you can use AutoMapper to update the entity properties
        // _mapper.Map(request, existingBeach);

        await _myWorldDbContext.SaveToDbAsync(); // Save changes to the database

        return existingBeach.Id; // Return the ID of the updated beach
    }
}
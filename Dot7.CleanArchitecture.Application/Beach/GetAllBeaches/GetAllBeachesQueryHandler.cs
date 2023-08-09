using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dot7.CleanArchitecture.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dot7.CleanArchitecture.Application.Beach.GetAllBeaches
{
    public class GetAllBeachesQueryHandler : IRequestHandler<GetAllBeachesRequest, GetAllBeachesResponseWithCount>
    {
        private readonly IMyWorldDbContext _myWorldDbContext;
        private readonly IMapper _mapper;

        public GetAllBeachesQueryHandler(IMyWorldDbContext myWorldDbContext, IMapper mapper)
        {
            _myWorldDbContext = myWorldDbContext;
            _mapper = mapper;
        }

        public async Task<GetAllBeachesResponseWithCount> Handle(GetAllBeachesRequest request, CancellationToken cancellationToken)
        {
            var query = _myWorldDbContext.Beach.AsQueryable();

            if (!string.IsNullOrEmpty(request.Place))
            {
                query = query.Where(b => b.Place.Contains(request.Place));
            }
            if (!string.IsNullOrEmpty(request.BeachName))
            {
                query = query.Where(b => b.BeachName.Contains(request.BeachName));
            }

            // Calculate the total count of matching records
            int totalCount = await query.CountAsync(cancellationToken);

            int pageNumber = request.PageNumber; // The page number requested by the client
            int pageSize = request.PageSize;     // The page size requested by the client

            // Calculate the number of items to skip based on the page number and size
            int itemsToSkip = (pageNumber - 1) * pageSize;

            query = query.OrderBy(b => b.Id)
                         .Skip(itemsToSkip)
                         .Take(pageSize);

            // Project the results into GetAllBeachesResponse using AutoMapper
            var paginatedBeaches = await query.ProjectTo<GetAllBeachesResponse>(_mapper.ConfigurationProvider)
                                              .ToListAsync(cancellationToken);

            // Create the response model with the paginated records and the total count
            var response = new GetAllBeachesResponseWithCount
            {
                Beaches = paginatedBeaches,
                TotalCount = totalCount
            };

            return response;
        }
    }
}

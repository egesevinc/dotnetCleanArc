using AutoMapper;
using Dot7.CleanArchitecture.Application.Context;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dot7.CleanArchitecture.Application.Beach.DeleteBeach
{
    public class DeleteBeachCommandHandler : IRequestHandler<DeleteBeachRequest, int>
    {
        private readonly IMyWorldDbContext _myWorldDbContext;
        private readonly IMapper _mapper;

        public DeleteBeachCommandHandler(IMyWorldDbContext myWorldDbContext, IMapper mapper)
        {
            _myWorldDbContext = myWorldDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(DeleteBeachRequest request, CancellationToken cancellationToken)
        {
            var beachToDelete = _myWorldDbContext.Beach.FirstOrDefault(b => b.BeachName == request.BeachName);

            if (beachToDelete == null)
            {
                throw new InvalidOperationException("Beach not found");
            }

            _myWorldDbContext.Beach.Remove(beachToDelete);
             await _myWorldDbContext.SaveToDbAsync();
            return beachToDelete.Id; // Return the ID of the deleted beach
        }
    }
}

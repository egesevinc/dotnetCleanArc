
using Microsoft.EntityFrameworkCore;

namespace Dot7.CleanArchitecture.Application.Context;

public interface IMyWorldDbContext
{
    DbSet<Dot7.CleanArchitecture.Domain.Entities.Beach> Beach {get;}

    Task<int> SaveToDbAsync();
}
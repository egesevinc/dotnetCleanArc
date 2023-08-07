using Dot7.CleanArchitecture.Application;
using Dot7.CleanArchitecture.Application.Context;
using Dot7.CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dot7.CleanArchitecture.Infrastructure.Context;

public class MyWorldDbContext : DbContext, IMyWorldDbContext
{
    private readonly static string DevServerConnStr = "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

    public MyWorldDbContext() :

        this(new DbContextOptionsBuilder<MyWorldDbContext>()

            .UseSqlServer(DevServerConnStr)

            .Options)

    { }


    public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
    {

    }
    public DbSet<Beach> Beach { get; set; }
    public async Task<int> SaveToDbAsync()
    {
        return await SaveChangesAsync();
    }
}
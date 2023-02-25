using System;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace ApplicationIntegrationTests.Common;

public class SocialNetworkDbContextFactory
{
    public static SocialNetworkDbContext Create()
    {
        var options = new DbContextOptionsBuilder<SocialNetworkDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var dbContext = new SocialNetworkDbContext(options);
        return dbContext;
    }

    public static void Destroy(SocialNetworkDbContext dbContext)
    {
        dbContext.Database.EnsureDeleted();
        dbContext.Dispose();
    }
}
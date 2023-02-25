using System;
using Persistence;

namespace ApplicationIntegrationTests.Common;

public class BaseTest : IDisposable
{
    protected SocialNetworkDbContext DbContext;

    public BaseTest()
    {
        DbContext = SocialNetworkDbContextFactory.Create();
    }

    public void Dispose()
    {
        SocialNetworkDbContextFactory.Destroy(DbContext);
    }
}
using System.Reflection;
using Application.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SocialNetworkDbContext : DbContext, ISocialNetworkDbContext
{
    public DbSet<Blogger> Bloggers { get; set; }
    public DbSet<Post> Posts { get; set; }

    public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
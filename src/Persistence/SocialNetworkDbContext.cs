using Application.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class SocialNetworkDbContext : DbContext, ISocialNetworkDbContext
{
    public DbSet<Blogger> Bloggers { get; set; }
    public DbSet<Post> Posts { get; set; }
}
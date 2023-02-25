using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface ISocialNetworkDbContext
{
    public DbSet<Blogger> Bloggers { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
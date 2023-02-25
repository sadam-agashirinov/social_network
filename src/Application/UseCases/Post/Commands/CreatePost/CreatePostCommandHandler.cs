using Application.Interfaces;
using MediatR;

namespace Application.UseCases.Post.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand,Guid>
{
    private readonly ISocialNetworkDbContext _dbContext;

    public CreatePostCommandHandler(ISocialNetworkDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Domain.Entity.Post()
        {
            Id = Guid.NewGuid(),
            Text = request.Post,
            BloggerId = request.BloggerId,
            Created = DateTime.Now
        };
        await _dbContext.Posts.AddAsync(post, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return post.Id;
    }
}
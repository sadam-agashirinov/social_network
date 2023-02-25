using MediatR;

namespace Application.UseCases.Post.Commands.CreatePost;

public class CreatePostCommand : IRequest<Guid>
{
    public Guid BloggerId { get; set; }
    public string Post { get; set; } = null!;
}
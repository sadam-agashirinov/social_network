using FluentValidation;

namespace Application.UseCases.Post.Commands.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.BloggerId)
            .NotEqual(Guid.Empty)
            .WithMessage("Идентификатор пользователя имеет неверное значение.");

        RuleFor(x => x.Post)
            .MinimumLength(100)
            .WithMessage("Минимально допустимое кол-во символов в посте 100.")
            .MaximumLength(500)
            .WithMessage("Превышено максимально допустимое кол-во символов в посте.");
    }
}
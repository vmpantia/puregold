using FluentValidation;

namespace Puregold.Application.Items.Create;

public sealed class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    public CreateItemCommandValidator()
    {
        RuleFor(cic => cic.Item.Name).NotEmpty();
        RuleFor(cic => cic.Item.CategoryId).NotEmpty();
    }
}
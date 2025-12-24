using MediatR;
using Puregold.Domain.Common.Responses;

namespace Puregold.Application.ItemCategories.Create;

public sealed record CreateItemCategoryCommand(CreateItemCategoryDto ItemCategory) : IRequest<Result<Guid>>;
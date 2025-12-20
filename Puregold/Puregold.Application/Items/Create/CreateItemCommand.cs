using MediatR;
using Puregold.Domain.Common.Responses;

namespace Puregold.Application.Items.Create;

public sealed record CreateItemCommand(CreateItemDto Item) : IRequest<Result<Guid>>;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Puregold.Application.Items.Create;

namespace Puregold.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ItemsController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateItemAsync(CreateItemDto request) => await SendRequestAsync(new CreateItemCommand(request));
}
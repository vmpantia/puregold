using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Puregold.Application.ItemCategories.Create;
using Puregold.Application.Items.Create;
using Puregold.Domain.Enums;

namespace Puregold.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ItemsController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost, Authorize(Roles = nameof(UserRole.Admin))]
    public async Task<IActionResult> CreateItemAsync(CreateItemDto request) => await SendRequestAsync(new CreateItemCommand(request));
    
    [HttpPost("Categories"), Authorize(Roles = nameof(UserRole.Admin))]
    public async Task<IActionResult> CreateItemCategoryAsync(CreateItemCategoryDto request) => await SendRequestAsync(new CreateItemCategoryCommand(request));
}
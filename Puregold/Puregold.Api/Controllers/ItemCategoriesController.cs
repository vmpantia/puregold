using MediatR;
using Microsoft.AspNetCore.Mvc;
using Puregold.Application.ItemCategories.Create;

namespace Puregold.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemCategoriesController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateIteCategoryAsync(CreateItemCategoryDto request) => await SendRequestAsync(new CreateItemCategoryCommand(request));
}
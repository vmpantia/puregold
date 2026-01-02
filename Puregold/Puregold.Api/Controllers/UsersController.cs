using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Puregold.Application.Users.Create;
using Puregold.Domain.Enums;

namespace Puregold.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("Create/{role}")]
    [Authorize(Roles = nameof(UserRole.Admin))]
    public async Task<IActionResult> CreateUserAsync(CreateUserDto request, UserRole role) => await SendRequestAsync(new CreateUserCommand(request, role));
}
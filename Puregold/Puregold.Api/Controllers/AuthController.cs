using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Puregold.Application.Users.Login;

namespace Puregold.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost("Login"), AllowAnonymous]
    public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserDto dto) => await SendRequestAsync(new LoginUserCommand(dto));
}
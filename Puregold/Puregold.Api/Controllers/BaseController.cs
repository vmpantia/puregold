using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Puregold.Api.Extensions;
using Puregold.Domain.Common.Responses;
using Puregold.Domain.Enums;

namespace Puregold.Api.Controllers;

public class BaseController(IMediator mediator) : ControllerBase
{
    protected async Task<IActionResult> SendRequestAsync<TResponse>(IRequest<Result<TResponse>> request)
    {
        try
        {
            // Send a request to command or query
            var result = await mediator.Send(request);
            
            return result switch
            {
                { IsSuccess: false, Error: { Type: ErrorType.NotFound } } => NotFound(result),
                { IsSuccess: false } => BadRequest(result),
                _ => Ok(result)
            };
        }
        catch (ValidationException ex)
        {
            var error = CommonErrors.Validation(ex.Errors.ToDictionary());
            return BadRequest((Result<TResponse>)error);
        }
        catch (Exception ex)
        {
            return BadRequest((Result<TResponse>)CommonErrors.Unexpected(ex));
        }
    }
}
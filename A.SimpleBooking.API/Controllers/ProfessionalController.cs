using B.SimpleBooking.Application.Services.ResultPattern.CustomErrors;
using B.SimpleBooking.Application.UseCases.Professionals.CreateProfessional;
using B.SimpleBooking.Application.UseCases.Professionals.UpdateProfessional;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace A.SimpleBooking.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProfessionalController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfessionalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProfessionalCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: _ => Ok(),
            onFailure: error => error switch
            {
                ConflictError conflictError => Conflict(new { message = conflictError.Message }),
                ValidationError validationError => BadRequest(new { Errors = validationError.Failures.Select(m => m.ErrorMessage) }),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            });
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateProfessionalCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: success => Ok(success),
            onFailure: fail => fail switch
            {
                ValidationError validationError => BadRequest(new { Errors = validationError.Failures.Select(m => m.ErrorMessage) }),
                NotFoundError notFoundError => NotFound(new { message = notFoundError.Message }),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            }
            );
    }
}

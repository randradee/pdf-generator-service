using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PdfGeneratorService.Application.Features.Auth.Commands;

namespace PdfGeneratorService.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> Login([FromBody] GenerateTokenCommand command)
    {
        var token = await _mediator.Send(command);

        if (string.IsNullOrWhiteSpace(token))
            return Unauthorized("Usuário ou senha inválidos.");

        return Ok(token);
    }
    
    [HttpPost("create")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result)
            return BadRequest(new { message = "Usuário já existe." });

        return Ok(new { message = "Usuário cadastrado com sucesso." });
    }
}
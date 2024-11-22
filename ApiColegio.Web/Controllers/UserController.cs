using ApiColegio.Application.Features.Users.Commands.CreateUser;
using ApiColegio.Application.Features.Users.Commands.DeleteUser;
using ApiColegio.Application.Features.Users.Commands.LoginUser;
using ApiColegio.Application.Features.Users.Commands.UpdateUser;
using ApiColegio.Application.Features.Users.Queries.GetActiveUsers;
using ApiColegio.Application.Features.Users.Queries.GetUserByName;
using ApiColegio.Application.Features.Users.Queries.GetUsersByRole;
using ApiColegio.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiColegio.Web.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess) 
        {
            return Ok("User created successfully");
        }
        else
        {
            return BadRequest(result.Error);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
        {
            return Ok("User updated successfully");
        }
        else
        {
            return BadRequest(result.Error);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _mediator.Send(new DeleteUserCommand(id));

        if (result.IsSuccess)
        {
            return Ok("User deleted successfully");
        }
        else
        {
            return BadRequest(result.Error);
        }
    }

    [HttpGet("active")]
    public async Task<ActionResult<Pageable>> GetActiveUsers(
   [FromQuery] int pageSize,
   [FromQuery] int pageNumber,
   CancellationToken cancellationToken)
    {
        var query = new GetActiveUsersQuery(pageNumber, pageSize);

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);  
        }
        return BadRequest(result.Error);   
    }
    [HttpGet("GetByName")]
    public async Task<ActionResult<Pageable>> GetUsersByName(
    [FromQuery] string name,
    [FromQuery] int pageSize,
    [FromQuery] int pageNumber,
    CancellationToken cancellationToken)
    {
        var query = new GetUsersByNameQuery(name, pageNumber, pageSize);

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Error);
    }

    [HttpGet("GetByRole")]
    public async Task<ActionResult<Pageable>> GetUsersByRole(
    [FromQuery] string role,
    [FromQuery] int pageSize,
    [FromQuery] int pageNumber,
    CancellationToken cancellationToken)
    {
        var query = new GetUsersByRoleQuery(role, pageNumber, pageSize);

        var result = await _mediator.Send(query, cancellationToken);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.Error);
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return result.IsSuccess
            ? Ok(new { Token = result.Data })
            : BadRequest(new { Error = result.ErrorCode });
    }
}

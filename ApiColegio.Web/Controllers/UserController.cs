using ApiColegio.Application.Features.Users.Commands.CreateUser;
using ApiColegio.Application.Features.Users.Commands.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiColegio.Web.Controllers
{
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
    }
}

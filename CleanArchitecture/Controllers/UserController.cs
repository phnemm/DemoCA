using CleanArchitecture.Api.Controllers.ResponseTypes;
using CleanArchitecture.Application.Common.Security;
using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Application.Users.CreateUser;
using CleanArchitecture.Application.Users.DeleteUser;
using CleanArchitecture.Application.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ISender _mediator;
        public UserController(ISender mediator)
        {                
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPut("update-user")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> Update(
                    [FromBody] UpdateUserCommand command,
                    CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return CreatedAtAction(nameof(Update), new { id = result }, new JsonResponse<Guid>(result));
        }

        [HttpDelete("delete-user")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<JsonResponse<Guid>>> Delete(
                    [FromBody] DeleteUserCommand command,
                    CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            //return CreatedAtAction(nameof(GetOrderById), new { id = result }, new JsonResponse<Guid>(result));
            return CreatedAtAction(nameof(Delete), new { id = result }, new JsonResponse<Guid>(result));
        }
    }
}

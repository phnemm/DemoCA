//using CleanArchitecture.Api.Controllers.ResponseTypes;
//using CleanArchitecture.Application.Common.Security;
//using CleanArchitecture.Application.Products;
//using CleanArchitecture.Application.Products.CreateProduct;
//using CleanArchitecture.Application.Products.DeleteProduct;
//using CleanArchitecture.Application.Products.GetAllProduct;
//using CleanArchitecture.Application.Products.GetProductById;
//using CleanArchitecture.Application.Products.UpdateProduct;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Net.Mime;

//namespace CleanArchitecture.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize]
//    public class ProductController : ControllerBase
//    {
//        private readonly ISender _mediator;

//        public ProductController(ISender mediator)
//        {
//            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
//        }

//        [HttpGet("get-all")]
//        [Produces(MediaTypeNames.Application.Json)]
//        [ProducesResponseType(typeof(JsonResponse<List<ProductDto>>), StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [ProducesResponseType(StatusCodes.Status403Forbidden)]
//        [ProducesResponseType(typeof(ProblemDetails) ,StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<JsonResponse<List<ProductDto>>>> GetAllProduct(CancellationToken cancellationToken = default)
//        {
//            var result = await _mediator.Send(new GetAllProductQuery(), cancellationToken);
//            return result == null ? NotFound() : Ok(result);
//        }

//        [HttpGet("get-by-id/{id}")]
//        [Produces(MediaTypeNames.Application.Json)]
//        [ProducesResponseType(typeof(JsonResponse<List<ProductDto>>), StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [ProducesResponseType(StatusCodes.Status403Forbidden)]
//        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<JsonResponse<List<ProductDto>>>> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken = default)
//        {
//            var result = await _mediator.Send(new GetProductByIdQuery(id: id), cancellationToken);
//            return result == null ? NotFound() : Ok(result);
//        }

//        [HttpPost("create-product")]
//        [Produces(MediaTypeNames.Application.Json)]
//        [ProducesResponseType(typeof(JsonResponse<Guid>), StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [ProducesResponseType(StatusCodes.Status403Forbidden)]
//        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<JsonResponse<Guid>>> CreateRole([FromBody] CreateProductCommand command, CancellationToken cancellationToken = default)
//        {
//            var result = await _mediator.Send(command, cancellationToken);
//            return CreatedAtAction(nameof(CreateRole), new { id = result }, new JsonResponse<Guid>(result));
//        }

//        [HttpDelete("remove-product/{id}")]
//        [Produces(MediaTypeNames.Application.Json)]
//        [ProducesResponseType(typeof(JsonResponse<ProductDto>), StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [ProducesResponseType(StatusCodes.Status403Forbidden)]
//        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
//        public async Task<ActionResult<JsonResponse<ProductDto>>> RemoveProduct([FromRoute] Guid id, CancellationToken cancellationToken = default)
//        {
//            var result = await _mediator.Send(new DeleteProductCommand(id: id), cancellationToken);
//            return result == null ? NotFound() : Ok(result);
//        }

//        [HttpPut("update-product/{id}")]
//        [Produces(MediaTypeNames.Application.Json)]
//        [ProducesResponseType(typeof(JsonResponse<ProductDto>), StatusCodes.Status201Created)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
//        [ProducesResponseType(StatusCodes.Status403Forbidden)]
//        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status501NotImplemented)]
//        public async Task<ActionResult<ProductDto>> UpdateRole([FromRoute] Guid id, [FromBody] UpdateProductCommand command, CancellationToken cancellationToken = default)
//        {
//            if (command.Id == default)
//                command.Id = id;
//            if (id != command.Id)
//                return BadRequest();
//            var result = await _mediator.Send(command, cancellationToken);
//            return result == null ? NotFound() : Ok(result);
//        }
//    }
//}

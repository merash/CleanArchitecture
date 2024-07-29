using CleanArchitecture.Application.UseCases.Products.Commands.CreateProductCommand;
using CleanArchitecture.Application.UseCases.Products.Commands.UpdateProductCommand;
using CleanArchitecture.Application.UseCases.Products.Queries.GetByProductIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> InsertAsync([FromBody] CreateProductCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);
            if (response.succcess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateProductCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);
            if (response.succcess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] long ProductId)
        {
            var response = await _mediator.Send(new GetByProductIdQuery() { ProductId = ProductId });
            if (response.succcess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}

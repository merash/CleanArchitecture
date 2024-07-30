using CleanArchitecture.Application.UseCases.Products.Commands.CreateProductCommand;
using CleanArchitecture.Application.UseCases.Products.Commands.UpdateProductCommand;
using CleanArchitecture.Application.UseCases.Products.Queries.GetByProductIdQuery;
using CleanArchitecture.Application.UseCases.Products.Queries.GetProductsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> InsertAsync([FromBody] CreateProductCommand command)
        {
            if (command is null) return BadRequest();

            var response = await this.mediator.Send(command);
            if (response.succcess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateProductCommand command)
        {
            if (command is null) return BadRequest();

            var response = await this.mediator.Send(command);
            if (response.succcess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("GetById/{ProductId}")]
        public async Task<IActionResult> GetById(long ProductId)
        {
            var response = await this.mediator.Send(new GetByProductIdQuery() { ProductId = ProductId });
            if (response.succcess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var response = await this.mediator.Send(new GetProductsQuery());
            if (response.succcess)
                return Ok(response);

            return BadRequest(response);
        }
    }
}

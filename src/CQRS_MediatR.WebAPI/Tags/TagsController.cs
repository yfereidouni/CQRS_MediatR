using Azure;
using CQRS_MediatR.Model.Tags.Commands;
using CQRS_MediatR.Model.Tags.Queries;
using CQRS_MediatR.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR.WebAPI.Tags
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : BaseController
    {
        public TagsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("CreateTag")]
        public async Task<IActionResult> CreateTag(CreateTag tag)
        {
            var response = await _mediator.Send(tag);

            return response!=null ? Ok(response) : BadRequest();
        }

        [HttpPut("UpdateTag")]
        public async Task<IActionResult> UpdateTag([FromBody]UpdateTag tag)
        {
            var response = await _mediator.Send(tag);

            return response != null ? Ok(response) : BadRequest();
        }

        [HttpGet("SearchTag")]
        public async Task<IActionResult> SearchTag([FromQuery] FilterByName tag)
        {
            var response = await _mediator.Send(tag);

            return response != null ? Ok(response) : BadRequest();
        }
    }
}

﻿using Azure;
using CQRS.MediatR.Model.Tags.Commands;
using CQRS.MediatR.WebAPI.Framework;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.MediatR.WebAPI.Tags
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
    }
}
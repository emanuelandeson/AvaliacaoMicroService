using FCamara.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FCamara.API.Controllers
{
    public class ApiController:ControllerBase
    {
        public readonly IMediator _mediator;
        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected new IActionResult Response(Response result = null)
        {
            if (!result.HasMessages)
            {
                return Ok(new
                {
                    success = true,
                    data = result?.Value
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = result.Messages
            });
        }
    }
}

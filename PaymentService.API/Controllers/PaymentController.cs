using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PaymentService.API.Features;
using PaymentService.API.Features.PaymentRange;
using Shared.Models.Models;
using System;
using System.Threading.Tasks;

namespace PaymentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Payment([FromBody] PaymentCommad request)
        {
            var result = _mediator.Send(request);
            return Ok("Status  " + result);
        }

        [HttpPost]
        [Route("PaymentRange")]
        public IActionResult PaymentRange([FromBody] PaymentRangeCommand request)
        {
            var result = _mediator.Send(request);
            return Ok("Status  " + result.Result);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.AddResidenceDues;
using ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.AddResidenceDuesRange;
using ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.DeleteResidenceDues;
using ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.UpdateResidenceDues;
using ResidenceManagement.Application.Features.Queries.ResidenceDues.GetResidenceDues;
using ResidenceManagement.Application.Features.Queries.ResidenceDues.GetResidenceDuessByUser;
using ResidenceManagement.Application.Features.Queries.ResidenceDuesControl.GetUnpaidDueses;
using ResidenceManagement.Infrastructure.Security.Extensions;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ResidenceDuesController : ControllerBase
    {
        private IMediator _mediator;

        public ResidenceDuesController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {

            return Ok(_mediator.Send(new GetResidenceDuesListQuery()));
        }
        [HttpGet]
        [Route("GetByUser")]

        public IActionResult GetByUser( )
        {
            var request = new GetResidenceDuesByUserQuery();
            var currentUserId = User.GetUserId();
            request.UserId = int.Parse(currentUserId);
            return Ok(_mediator.Send(request));
        }

        [HttpGet]
        [Route("GetUnpaidDues")]

        public IActionResult GetUnpaidDues()
        {
            var request = new GetUnpaidDuesQuery();
            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Add([FromBody] AddResidenceDuesCommand request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete([FromBody] DeleteResidenceDuesCommand request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]

        public IActionResult Update([FromBody] UpdateResidenceDuesCommand request)
        {

            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        [Route("AddRange")]
        [Authorize(Roles = "Admin")]

        public IActionResult AddRand([FromBody] AddRangeResidenceDuesCommand request)
        {
            return Ok(_mediator.Send(request));
        }
    }
}

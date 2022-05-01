using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Features.Commands.DuesControl.AddDues;
using ResidenceManagement.Application.Features.Commands.DuesControl.AddDuesRange;
using ResidenceManagement.Application.Features.Commands.DuesControl.DeleteDues;
using ResidenceManagement.Application.Features.Commands.DuesControl.UpdateDues;
using ResidenceManagement.Application.Features.Queries.DuesController.GetDues;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class DuessesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DuessesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddDuesCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetDuesListQuery()));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteDuesCommand request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateDuesCommand request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        [Route("AddRange")]
        public IActionResult AddRange([FromBody] AddDuesRangeCommand request)
        {
            return Ok(_mediator.Send(request));
        }
    }
}

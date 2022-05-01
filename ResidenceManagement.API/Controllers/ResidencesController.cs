using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Features.Commands.Residences.AddResidence;
using ResidenceManagement.Application.Features.Commands.Residences.AddResidenceRange;
using ResidenceManagement.Application.Features.Commands.Residences.DeleteResidence;
using ResidenceManagement.Application.Features.Commands.Residences.DeleteResidenceBlock;
using ResidenceManagement.Application.Features.Commands.Residences.UpdateResidence;
using ResidenceManagement.Application.Features.Queries.Residences.GetResidences;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class ResidencesController : ControllerBase
    {
        private readonly IMediator _mediator;     

        public ResidencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           
            var result = _mediator.Send(new GetResidenceListQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddResidenceCommand addResidence)
        {
            var result= await (_mediator.Send(addResidence));
            return Ok(result);

        }


        [HttpPost]
        [Route("range")]

        public async Task<IActionResult> AddRange([FromBody] AddResidenceRangeCommand addResidence)
        {
            var result = await (_mediator.Send(addResidence));
            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteResidenceCommand deleteResidence)
        {
            var result = await (_mediator.Send(deleteResidence));
            return Ok(result);

        }

        [HttpDelete]
        [Route("block")]

        public async Task<IActionResult> DeleteBlock([FromBody] DeleteResidenceBlockCommand deleteResidence)
        {
            var result = await (_mediator.Send(deleteResidence));
            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateResidenceCommand updateResidence)
        {
            var result = await (_mediator.Send(updateResidence));
            return Ok(result);

        }

    }
}

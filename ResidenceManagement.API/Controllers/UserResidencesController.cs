using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Features.Commands.UserResidences.AddUserResidence;
using ResidenceManagement.Application.Features.Commands.UserResidences.DeleteUserResidence;
using ResidenceManagement.Application.Features.Commands.UserResidences.UpateUserResidence;
using ResidenceManagement.Application.Features.Queries.Residences.GetUserResidences;
using ResidenceManagement.Application.Features.Queries.UserResidences.GetUserResidenceByResident;
using ResidenceManagement.Infrastructure.Security.Extensions;
using System.Security.Claims;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserResidencesController : ControllerBase
    {
        private IMediator _mediator;

        public UserResidencesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]

        public ActionResult Get()

        {
            var result = _mediator.Send(new GetUserResidenceListQuery());
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Add([FromBody] AddUserResidenceCommand command)
        {
            var res = _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet]
        [Route("Resident")]
        public IActionResult GetResident()
        {
            //var currentUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUserId = User.GetUserId();

            var request = new GetResidenceByResidentQuery();
            request.UserId = int.Parse(currentUserId);
            return Ok(_mediator.Send(request));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete(int id)
        {
            var deleteId = id;
            var result = new DeleteUserResidenceCommand() { DeleteItemId = id };
            return Ok(_mediator.Send(result));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]

        public IActionResult Update([FromBody] UpdateUserResidenceCommand request)
        {
            return Ok(_mediator.Send(request));

        }

        [HttpGet]
        [Route("GetByUser")]

        public IActionResult GetByUser()
        {
            var request = new GetResidenceByResidentQuery();
            var currentUserId = User.GetUserId();
            request.UserId = int.Parse(currentUserId);
            return Ok(_mediator.Send(request));
        }

    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Features.Queries.UserResidences.GetUserResidenceByResident;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ResidentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResidentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetResidenceByResidentQuery request)
        {
         
            return Ok(_mediator.Send(request));
        }


        
    }
}

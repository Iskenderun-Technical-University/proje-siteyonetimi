using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Features.Commands.ResidenceInvoices.AddResidenceInvoice;
using ResidenceManagement.Application.Features.Commands.ResidenceInvoices.AddResidenceInvoiceRange;
using ResidenceManagement.Application.Features.Commands.ResidenceInvoices.DeleteResidenceInvoice;
using ResidenceManagement.Application.Features.Commands.ResidenceInvoices.UpdateResidenceInvoice;
using ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetResidenceInvoices;
using ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetResidenceInvoicesByUser;
using ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetUnpaidInvoices;
using ResidenceManagement.Infrastructure.Security.Extensions;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResidenceInvoicesController : ControllerBase
    {
        private IMediator _mediator;
        private IResidenceInvoiceRepository _repository;

        public ResidenceInvoicesController(IMediator mediator, IResidenceInvoiceRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }


        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Get()
        {
            return Ok(_mediator.Send(new GetResidenceInvoiceListQuery()));
        }
        [HttpGet]
        [Route("GetAllDetails")]
        [Authorize(Roles = "Admin")]

        public IActionResult GetAllDetails()
        {
            return Ok(_repository.GetAllDetails());
        }
        
       [HttpGet]
        [Route("GetByUser")]

        public IActionResult GetByUser()
        {
            var request = new GetResidenceInvoiceByUserQuery();
            var currentUser = User.GetUserId();
            request.UserId = int.Parse(currentUser);
            return Ok(_mediator.Send(request));
        }
        

        [HttpGet]
        [Route("GetUnpaidInvoice")]

        public IActionResult GetUnpaidInvoice()
        {
            var request = new GetUnpaidInvoicesQuery();
            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public IActionResult Add([FromBody] AddResidenceInvoiceCommand request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]

        public IActionResult Delete([FromBody] DeleteResidenceInvoiceCommand request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpPut]
       [Authorize(Roles = "Admin")]

        public IActionResult Update([FromBody] UpdateResidenceInvoiceCommand request)
        {

            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        [Route("AddRange")]
       [Authorize(Roles = "Admin")]

        public IActionResult AddRange([FromBody] AddRangeResidenceInvoiceCommand request)
        {
            return Ok(_mediator.Send(request));
        }
    }


}

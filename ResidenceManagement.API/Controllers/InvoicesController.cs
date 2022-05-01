using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Features.Commands.Invoices.AddInvoice;
using ResidenceManagement.Application.Features.Commands.Invoices.AddInvoiceRange;
using ResidenceManagement.Application.Features.Commands.Invoices.DeleteInvoice;
using ResidenceManagement.Application.Features.Commands.Invoices.UpdateInvoice;
using ResidenceManagement.Application.Features.Queries.Invoices.GetInvoices;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class InvoicesController : ControllerBase
    {
        private IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetInvoiceListQuery()));
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddInvoiceCommand request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpDelete]
        public IActionResult Add([FromBody] DeleteInvoiceCommand request)
        {
            return Ok(_mediator.Send(request));
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateInvoiceCommand request)
        {

            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        [Route("AddRange")]
        public IActionResult AddRange([FromBody] AddInvoiceRangeCommand request)
        {
            return Ok(_mediator.Send(request));
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ResidenceManagement.Application.Features.Commands.Payments.DuesPayments.PayDues;
using ResidenceManagement.Application.Features.Commands.Payments.InvoicePayments.PayInvoices;
using ResidenceManagement.Application.Features.Queries.ResidenceDues.GetResidenceDuessByUser;
using ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetResidenceInvoicesByUser;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Domain.Entities.Managements;
using ResidenceManagement.Infrastructure.Security.Extensions;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserPaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IConnection connection;
        //private readonly ConnectionFactory factory;

        public UserPaymentsController(IMediator mediator)
        {
            _mediator = mediator;



        }

        [HttpGet]
        [Route("getDues")]
        public IActionResult GetDues([FromQuery] GetResidenceDuesByUserQuery request)
        {
            int currentUserId = int.Parse(User.GetUserId());
            request.UserId = currentUserId;
            return Ok(_mediator.Send(request));
        }

        [HttpGet]
        [Route("getInvoices")]
        public IActionResult GetInvoices([FromQuery] GetResidenceInvoiceByUserQuery request)
        {
            int currentUserId = int.Parse(User.GetUserId());
            request.UserId = currentUserId;
            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        [Route("payInvoices")]
        public IActionResult PayInvoices([FromQuery] PayInvoicesCommand request)
        {

            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        [Route("payInvoiceRabbit")]
        public IActionResult PayInvoiceRabbit([FromQuery] PayRabbitDto request)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "admin", Password = "123456" }; using (IConnection connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                     queue: "customer",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                var customerPayload = JsonSerializer.Serialize(request);

                var body = Encoding.UTF8.GetBytes(customerPayload);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "customer",
                    basicProperties: null,
                    body: body
                );
            }
            return Ok(request);
        }

        [HttpPost]
        [Route("payDues")]
        public IActionResult PayDues([FromQuery] PayDuesCommand request)
        {
            return Ok(_mediator.Send(request));
        }

      
    }
}

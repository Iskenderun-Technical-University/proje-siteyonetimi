using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using ResidenceManagement.Application.Features.Commands.Payments.InvoicePayments.PayInvoices;
using ResidenceManagement.Application.Models.PaymentControl;
using System.Text;
using System.Text.Json;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ConnectionFactory factory;
        private readonly IConnection connection;

        public HomeController()
        {
            factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "123456"
            };

            connection = factory.CreateConnection();
        }

        [HttpPost("postRabbit")]
        public IActionResult Get([FromBody] PaymentDto request)
        {
            var customer = request;

            using (var channel = this.connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "request1",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var customerPayload = JsonSerializer.Serialize(request);

                var body = Encoding.UTF8.GetBytes(customerPayload);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "request1",
                    basicProperties: null,
                    body: body
                );
            }

            return Ok(request);
        }
    }
}

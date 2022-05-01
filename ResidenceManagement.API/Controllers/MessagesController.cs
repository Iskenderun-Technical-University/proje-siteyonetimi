using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Features.Commands.Messages.CheckReadMessage;
using ResidenceManagement.Application.Features.Commands.Messages.DeleteMessage;
using ResidenceManagement.Application.Features.Commands.Messages.SendMessage;
using ResidenceManagement.Application.Features.Queries.Messages.GetMessages;
using ResidenceManagement.Infrastructure.Security.Extensions;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] SendMessageCommand request)
        {
            int currentUserId = int.Parse(User.GetUserId());
            if (currentUserId != 1)
                request.ReceiverId = 1;
           
            request.SenderId = currentUserId;
            return Ok(_mediator.Send(request));
        }

        [HttpGet]
        [Route("GetByUser")]
        public IActionResult GetByUser()
        {
            var request = new GetMessageQuery();
            int currentUserId = int.Parse(User.GetUserId());
            request.UserId = currentUserId;
            return Ok(_mediator.Send(request));
        }

        [HttpPut]
        public IActionResult CheckRead([FromBody] CheckReadMessageCommand request)
        {
            int currentUserId = int.Parse(User.GetUserId());
            request.UserId = currentUserId;
            return Ok(_mediator.Send(request));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteMessageCommand request)
        {
            int currentUserId = int.Parse(User.GetUserId());
            request.UserId = currentUserId;
            return Ok(_mediator.Send(request));
        }
    }
}

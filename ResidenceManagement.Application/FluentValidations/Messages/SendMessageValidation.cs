using FluentValidation;
using ResidenceManagement.Application.Features.Commands.Messages.SendMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.Messages
{
    public class SendMessageValidation : AbstractValidator<SendMessageCommand>
    {
        public SendMessageValidation()
        {
            RuleFor(p=>p.Title).NotEmpty();
            RuleFor(p => p.Content).NotEmpty();
        }
    }
}

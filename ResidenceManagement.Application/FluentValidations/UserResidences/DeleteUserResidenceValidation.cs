using FluentValidation;
using ResidenceManagement.Application.Features.Commands.UserResidences.DeleteUserResidence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.UserResidences
{
    public class DeleteUserResidenceValidation : AbstractValidator<DeleteUserResidenceCommand>
    {
        public DeleteUserResidenceValidation()
        {
            RuleFor(p=>p.DeleteItemId).NotEmpty().LessThan(0);
        }
    }
}

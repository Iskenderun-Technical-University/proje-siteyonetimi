using FluentValidation;
using ResidenceManagement.Application.Features.Commands.UserResidences.UpateUserResidence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.UserResidences
{
    public class UpdateUserResidenceValidation : AbstractValidator<UpdateUserResidenceCommand>
    {
        public UpdateUserResidenceValidation()
        {
            RuleFor(p=>p.ResidentTypeId).NotEmpty().LessThan(3);

        }
    }
}

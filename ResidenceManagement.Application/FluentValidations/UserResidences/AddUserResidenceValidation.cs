using FluentValidation;
using ResidenceManagement.Application.Features.Commands.UserResidences.AddUserResidence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.UserResidences
{
    public class AddUserResidenceValidation : AbstractValidator<AddUserResidenceCommand>
    {
        public AddUserResidenceValidation()
        {
            RuleFor(u => u.ResidentTypeId).LessThan(3);
            RuleFor(f => f.ResidenceId).NotEmpty();
        }
    }
}

using FluentValidation;
using ResidenceManagement.Application.Features.Commands.Residences.UpdateResidence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.Residences
{
    public class UpdateResidenceValidation : AbstractValidator<UpdateResidenceCommand>
    {
        public UpdateResidenceValidation()
        {
            RuleFor(r=>r.IsFull).NotNull();
        }
    }
}

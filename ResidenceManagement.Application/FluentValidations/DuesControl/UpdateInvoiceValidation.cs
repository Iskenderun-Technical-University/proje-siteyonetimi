using FluentValidation;
using ResidenceManagement.Application.Features.Commands.DuesControl.UpdateDues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.DuesControl
{
    public class UpdateDuesValidation : AbstractValidator<UpdateDuesCommand>
    {
        public UpdateDuesValidation()
        {
            RuleFor(r => r.Fee).GreaterThan(10);
        }
    }
}

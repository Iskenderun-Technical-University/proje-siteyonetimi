using FluentValidation;
using ResidenceManagement.Application.Features.Commands.DuesControl.AddDuesRange;

namespace ResidenceManagement.Application.FluentValidations.DuesControl
{
    public class AddDuesRangeValidation : AbstractValidator<AddDuesRangeCommand>
    {
        public AddDuesRangeValidation()
        {

            RuleFor(r => r.Fee).GreaterThan(10);
            RuleFor(r => r.Year).GreaterThan(1900);
        }
    }
}

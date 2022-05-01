using FluentValidation;
using ResidenceManagement.Application.Models.PaymentControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.Payments
{
    public class PaymentValidation : AbstractValidator<PaymentDto>
    {
        public PaymentValidation()
        {
            RuleFor(r => r.Fee).GreaterThan(10).NotEmpty().NotNull();
            RuleFor(r => r.Year).GreaterThan(1900).NotEmpty().NotNull();
            RuleFor(r => r.Month).LessThan(13).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}

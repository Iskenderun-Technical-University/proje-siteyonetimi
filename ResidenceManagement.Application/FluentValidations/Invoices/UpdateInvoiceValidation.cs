using FluentValidation;
using ResidenceManagement.Application.Features.Commands.Invoices.UpdateInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.Invoices
{
    public class UpdateInvoiceValidation : AbstractValidator<UpdateInvoiceCommand>
    {
        public UpdateInvoiceValidation()
        {
            RuleFor(r => r.Fee).GreaterThan(10);
        }
    }
}

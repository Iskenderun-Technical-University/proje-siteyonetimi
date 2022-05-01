using FluentValidation;
using ResidenceManagement.Application.Features.Commands.Invoices.AddInvoiceRange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.Invoices
{
    public class AddInvoiceRangeValidation : AbstractValidator<AddInvoiceRangeCommand>
    {
        public AddInvoiceRangeValidation()
        {
            RuleFor(r => r.Fee).GreaterThan(10);
            RuleFor(r => r.Year).GreaterThan(1900);
        }
    }
}

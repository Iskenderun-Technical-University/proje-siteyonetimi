using FluentValidation;
using ResidenceManagement.Application.Features.Commands.Authentications.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.Users
{
    public class UpdateUserValidator :AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(u=>u.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(u => u.NationalId).Length(11);
            RuleFor(u => u.FirstName).Matches(@"^[a-zA-Z ]+$");
            RuleFor(u => u.LastName).Matches(@"^[a-zA-Z ]+$");

        }
    }
}

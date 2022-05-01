using FluentValidation;
using ResidenceManagement.Application.Features.Queries.Authentications.SignInUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.Users
{
    public class SignInUserValidator : AbstractValidator<SignInUserQuery>
    {
        public SignInUserValidator()
        {

            RuleFor(p => p.Email).NotNull().NotEmpty().WithMessage("{Email Address} is required.");

            RuleFor(p => p.Password).NotNull().NotEmpty().WithMessage("{Password} is required.");

        }
    }
}

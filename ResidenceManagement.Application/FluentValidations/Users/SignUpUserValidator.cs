using FluentValidation;
using ResidenceManagement.Application.Features.Commands.Authentications.SignUpUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.FluentValidations.Users
{
    public class SignUpUserValidator : AbstractValidator<SignUpUserCommand>
    {
        public SignUpUserValidator()
        {

            RuleFor(p => p.Email).EmailAddress().NotEmpty().WithMessage("{Email Address} is required.");

            RuleFor(p => p.FirstName).NotEmpty().WithMessage("{FirstName} is required.");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("{LastName} is required.");
 
            RuleFor(p => p.NationalId).Length(11).WithMessage("National Identiyu must be 11 character");



        }
    }
}

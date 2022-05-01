using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Authentications.SignUpUser
{
    public class SignUpUserCommand : IRequest<IdentityResult>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarPlate { get; set; }
        public string NationalId { get; set; }


    }
}

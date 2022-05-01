using MediatR;
using ResidenceManagement.Application.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Authentications.SignInUser
{
    public class SignInUserQuery : IRequest<UserModel>
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

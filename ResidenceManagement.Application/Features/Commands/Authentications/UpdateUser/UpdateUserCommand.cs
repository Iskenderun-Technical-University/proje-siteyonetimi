using MediatR;
using Microsoft.AspNetCore.Identity;
using ResidenceManagement.Application.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Authentications.UpdateUser
{
    public class UpdateUserCommand : IRequest<IdentityResult>
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string CarPlate { get; set; }
    }
}

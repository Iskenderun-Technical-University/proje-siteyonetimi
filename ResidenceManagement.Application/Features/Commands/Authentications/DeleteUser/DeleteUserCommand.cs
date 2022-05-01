using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Authentications.DeleteUser
{
    public class DeleteUserCommand : IRequest<IdentityResult>
    {
   
        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ResidenceManagement.Domain.Entities.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Authentications.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var deleteUser =  await _userManager.FindByIdAsync(request.UserId.ToString());
            var result = await _userManager.DeleteAsync(deleteUser);
            return result;
        }
    }
}

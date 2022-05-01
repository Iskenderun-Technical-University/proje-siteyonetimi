using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResidenceManagement.Domain.Entities.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Authentications.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updateUser = _userManager.FindByIdAsync(request.UserId.ToString()).Result;
            
            updateUser.Email= request.Email;
            updateUser.CarPlate = request.CarPlate;
            updateUser.FirstName = request.FirstName;
            updateUser.LastName=request.LastName;
            updateUser.NationalId = request.NationalId;

            var result =  _userManager.UpdateAsync(updateUser);
            return result.Result;
           
           
        }
    }
}

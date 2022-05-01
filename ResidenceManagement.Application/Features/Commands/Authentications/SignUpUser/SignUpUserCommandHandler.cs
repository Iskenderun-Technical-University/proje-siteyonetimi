using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Domain.Entities.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Authentications.SignUpUser
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, IdentityResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;
        public SignUpUserCommandHandler(
                 IMapper mapper,
                 UserManager<User> userManager,
                 RoleManager<Role> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task<IdentityResult> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request);
           
            userEntity.UserName = userEntity.Email;
            var defaultPassword = "Abcd12!!";
            var checkNationalIdentity =await _userManager.Users.FirstOrDefaultAsync(r => r.NationalId == request.NationalId);
            if (checkNationalIdentity != null)
                throw new NotEmptyException("Tc no kayıtlı.");

            var checkCarPlate =await _userManager.Users.FirstOrDefaultAsync(r => r.CarPlate == request.CarPlate);

            if (checkCarPlate != null)
                throw new NotEmptyException("Araç plakası kayıtlı.");

            var userCreateResult = await _userManager.CreateAsync(userEntity, defaultPassword);
            
            if (userCreateResult.Succeeded)
            {
                await _userManager.Users.SingleOrDefaultAsync(u => u.Email == request.Email);
                await _userManager.AddToRoleAsync(userEntity, "User");
                return userCreateResult;
            }
      

            return userCreateResult;
        }

      
    }
}

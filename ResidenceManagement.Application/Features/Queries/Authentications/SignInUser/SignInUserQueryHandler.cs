using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.Users;
using ResidenceManagement.Domain.Entities.Auths;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Authentications.SignInUser
{
    public class SignInUserQueryHandler : IRequestHandler<SignInUserQuery, UserModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly RoleManager<Role> _roleManager;

        public SignInUserQueryHandler(UserManager<User> userManager,
           IMapper mapper,
           RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<UserModel> Handle(SignInUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);

            if (user == null)
                return null;

            var userModel = new UserModel();

            var userSigingResult = await _userManager.CheckPasswordAsync(user, request.Password);

            if (userSigingResult)
            {
                userModel = _mapper.Map<UserModel>(user);
                userModel.Roles = await _userManager.GetRolesAsync(user);
            }
            else
            {
                throw new ApplicationException("Şifre hatalı.");
            }

            return userModel;
        }
    }
}

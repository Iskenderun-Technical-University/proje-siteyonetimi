using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResidenceManagement.Application.Models.Users;
using ResidenceManagement.Domain.Entities.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Authentications.GetUsers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserListModel>>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public GetUserListQueryHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<UserListModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var list = await _userManager.Users.ToListAsync();
            var res = _mapper.Map<List<UserListModel>>(list);
            return res;
        }
    }
}

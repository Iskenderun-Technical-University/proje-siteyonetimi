using AutoMapper;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Models.UserResidences;
using ResidenceManagement.Domain.Entities.Managements;
using ResidenceManagement.Infrastructure.Contracts.Repositories.Commons;
using ResidenceManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Infrastructure.Contracts.Repositories
{
    public class UserResidenceRepository : RepositoryBase<UserResidence>, IUserResidenceRepository
    {
        private IMapper _mapper;
        protected string[] includes = { "User", "Residence", "ResidentType", "Residence.ResidenceType" };

        public UserResidenceRepository(SiteContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<UserResidenceDto>> GetAllUserResidenceDetail(Expression<Func<UserResidence, bool>> predicate = null)
        {

            var result = await base.GetAllAsync(predicate, includeStrings: includes);

            return _mapper.Map<IReadOnlyList<UserResidenceDto>>(result);
        }

        public async Task<UserResidenceDto> GetUserResidenceDetail()
        {
            var result = await base.GetAsync(includeStrings: includes);
            return _mapper.Map<UserResidenceDto>(result);
        }
    }
}

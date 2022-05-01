using Microsoft.EntityFrameworkCore.Query;
using ResidenceManagement.Application.Contracts.Repositories.Commons;
using ResidenceManagement.Application.Models.UserResidences;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Contracts.Repositories
{
    public interface IUserResidenceRepository : IRepositoryBase<UserResidence>
    {
        Task<UserResidenceDto> GetUserResidenceDetail();

        //Task<IReadOnlyList<UserResidenceDto>> GetAllUserResidenceDetail(Expression<Func<UserResidence, bool>> predicate = null);
       


    }
}

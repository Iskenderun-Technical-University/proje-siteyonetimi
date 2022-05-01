using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Domain.Entities.Managements;
using ResidenceManagement.Infrastructure.Contracts.Repositories.Commons;
using ResidenceManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Infrastructure.Contracts.Repositories
{
    public class ResidenceRepository : RepositoryBase<Residence>, IResidenceRepository
    {
        public ResidenceRepository(SiteContext dbContext) : base(dbContext)
        {
        }
    }
}

using MediatR;
using ResidenceManagement.Application.Models.UserResidences;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.UserResidences.GetUserResidenceByResident
{
    public class GetResidenceByResidentQuery : IRequest<List<UserResidenceDto>>
    {
        public int UserId { get; set; }

    }
}

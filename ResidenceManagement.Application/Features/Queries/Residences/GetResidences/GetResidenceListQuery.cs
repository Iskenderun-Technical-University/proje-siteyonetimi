using MediatR;
using ResidenceManagement.Application.Models.Residences;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Residences.GetResidences
{
    public class GetResidenceListQuery :IRequest<IReadOnlyList<ResidenceDto>>
    {
    }
}

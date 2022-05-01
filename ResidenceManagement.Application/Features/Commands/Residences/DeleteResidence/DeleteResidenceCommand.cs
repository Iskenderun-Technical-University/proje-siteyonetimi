using MediatR;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.DeleteResidence
{
    public class DeleteResidenceCommand : IRequest<DeleteResidenceResponse>
    {
        public int ResidenceId { get; set; }
    }
}

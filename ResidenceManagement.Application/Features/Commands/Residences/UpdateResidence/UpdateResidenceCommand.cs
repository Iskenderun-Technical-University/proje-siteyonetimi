using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.UpdateResidence
{
    public class UpdateResidenceCommand : IRequest<UpdateResidenceResponse>
    {
        public int Id { get; set; }
        public bool IsFull { get; set; }
        public int ResidenceTypeId { get; set; }
    }
}

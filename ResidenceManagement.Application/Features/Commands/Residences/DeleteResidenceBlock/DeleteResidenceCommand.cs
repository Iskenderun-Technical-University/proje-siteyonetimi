using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.DeleteResidenceBlock
{
    public class DeleteResidenceBlockCommand : IRequest<DeleteResidenceBlockResponse>
    {
        public int BlockNumber { get; set; }
    }
}

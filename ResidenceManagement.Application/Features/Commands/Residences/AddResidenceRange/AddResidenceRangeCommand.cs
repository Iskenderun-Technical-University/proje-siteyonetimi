using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.AddResidenceRange
{
    public class AddResidenceRangeCommand : IRequest<AddResidenceRangeResponse>
    {
        public int BlockNumber { get; set; }
        public int FloorPerBlock { get; set; }
        public int HousePerBlock { get; set; }
        public int ResidenceTypeId { get; set; }
    }
}

using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.AddResidenceRange
{
    public class AddResidenceRangeResponse
    {
        public AddResidenceRangeResponse(bool status)
        {
            Status = status;
        }

        public AddResidenceRangeResponse(bool status, Residence entity) : this(status)
        {

            Entity = entity;
        }
        public bool Status { get; set; }
        public Residence Entity { get; set; }
        
    }
}

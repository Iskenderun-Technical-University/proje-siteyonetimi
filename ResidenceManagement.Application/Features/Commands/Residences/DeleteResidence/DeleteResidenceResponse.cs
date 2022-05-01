using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.DeleteResidence
{
    public class DeleteResidenceResponse
    {
        public DeleteResidenceResponse(bool status)
        {
            Status = status;
        }

        public DeleteResidenceResponse(bool status, Residence entity) : this(status)
        {

            Entity = entity;
        }
        public bool Status { get; set; }
        public Residence Entity { get; set; }
    }
}

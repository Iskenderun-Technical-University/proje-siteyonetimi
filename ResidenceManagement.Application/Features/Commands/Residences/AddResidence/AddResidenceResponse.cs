using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Residences.AddResidence
{
    public class AddResidenceResponse
    {
       
        public AddResidenceResponse(bool status)
        {
            Status = status;
        }

        public AddResidenceResponse( bool status, Residence residence):this(status)
        {
           
            Residence = residence;
        }
        public bool Status { get; set; }
        public Residence Residence { get; set; }
    }
}

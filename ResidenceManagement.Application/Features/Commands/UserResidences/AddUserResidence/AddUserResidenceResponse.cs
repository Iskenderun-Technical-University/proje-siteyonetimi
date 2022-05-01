using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.UserResidences.AddUserResidence
{
    public class AddUserResidenceResponse
    {

        public AddUserResidenceResponse(bool status)
        {
            Status = status;
        }

        public AddUserResidenceResponse(bool status, Residence residence) : this(status)
        {

            Residence = residence;
        }
        public bool Status { get; set; }
        public Residence Residence { get; set; }
    }
}

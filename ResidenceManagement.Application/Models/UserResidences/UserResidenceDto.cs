using ResidenceManagement.Application.Models.Residences;
using ResidenceManagement.Application.Models.Users;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Models.UserResidences
{
    public class UserResidenceDto
    {
        public UserDto User { get; set; }

        public ResidenceDto Residence { get; set; }
       
        public string ResidentTypeType { get; set; }
    }
}

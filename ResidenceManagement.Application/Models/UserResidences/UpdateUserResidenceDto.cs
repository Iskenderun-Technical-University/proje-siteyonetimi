using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Models.UserResidences
{
    public class UpdateUserResidenceDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int ResidenceId { get; set; }

        public int ResidentTypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Models
{
    public class PaymentRangeShareModel
    {
        public int Fee { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public int PaymentType { get; set; }
        public IEnumerable<int> PaymentIds { get; set; }
    }
}

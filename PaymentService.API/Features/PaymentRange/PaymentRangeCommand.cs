using MediatR;
using System.Collections.Generic;

namespace PaymentService.API.Features.PaymentRange
{
    public class PaymentRangeCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CardNumber { get; set; }
        public int Fee { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public int PaymentType { get; set; }
        public IEnumerable<int> PaymentIds { get; set; }
    }
}

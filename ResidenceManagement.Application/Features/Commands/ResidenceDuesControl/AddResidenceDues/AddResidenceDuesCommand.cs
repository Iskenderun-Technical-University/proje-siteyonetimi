using MediatR;
using ResidenceManagement.Application.Responses;

namespace ResidenceManagement.Application.Features.Commands.ResidenceDuesControl.AddResidenceDues
{
    public class AddResidenceDuesCommand : IRequest<BaseResponse>
    {
        public int DuesId { get; set; }
        public int UserResidenceId { get; set; }

    }
}

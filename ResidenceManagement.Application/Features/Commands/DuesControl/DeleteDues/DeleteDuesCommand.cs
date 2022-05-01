using MediatR;
using ResidenceManagement.Application.Responses;

namespace ResidenceManagement.Application.Features.Commands.DuesControl.DeleteDues
{
    public class DeleteDuesCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}

using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Payments.DuesPayments.PayDues
{
    public class PayDuesCommandHandler : IRequestHandler<PayDuesCommand, BaseResponse>
    {
        private readonly IResidenceDuesRepository _residenceDuesRepository;

        public PayDuesCommandHandler(IResidenceDuesRepository residenceDuesRepository)
        {
            _residenceDuesRepository = residenceDuesRepository;
        }

        public async Task<BaseResponse> Handle(PayDuesCommand request, CancellationToken cancellationToken)
        {
            string[] includes = { "Dues", "UserResidence" };
            var getDeus = await _residenceDuesRepository.GetAsync(p=>p.Id == request.ResidenceDuesId,includeStrings:includes);
            var feeee = getDeus.Dues;
            if (getDeus == null)
                throw new NotFoundException("Aidat bulunamadı.");
            if (request.Fee == getDeus.Dues.Fee)
            {
                getDeus.IsPaid = true;
                await _residenceDuesRepository.UpdateAsync(getDeus);
                return new BaseResponse(true, "Ödeme başarılı.");
            }
            else
            {
                return new BaseResponse(false, "Ödeme gerçekleşmedi.");

            }

        }
    }
}

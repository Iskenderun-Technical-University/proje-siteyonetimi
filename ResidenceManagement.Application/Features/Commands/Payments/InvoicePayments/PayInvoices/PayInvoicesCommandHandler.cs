using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Payments.InvoicePayments.PayInvoices
{
    public class PayInvoicesCommandHandler : IRequestHandler<PayInvoicesCommand, BaseResponse>
    {
        private readonly IResidenceInvoiceRepository _residenceInvoicesRepository;
        protected string[] includes = { "Invoice", "UserResidence" };


        public PayInvoicesCommandHandler(IResidenceInvoiceRepository residenceInvoicesRepository)
        {
            _residenceInvoicesRepository = residenceInvoicesRepository;
        }

        public async Task<BaseResponse> Handle(PayInvoicesCommand request, CancellationToken cancellationToken)
        {
            var id = request.ResidenceInvoiceId;

            var getInvoice =await _residenceInvoicesRepository.GetAsync(predicate:r=>r.Id == request.ResidenceInvoiceId, includeStrings:includes);
            if (getInvoice == null)
                throw new NotFoundException(request);
            if(request.Fee == getInvoice.Invoice.Fee)
            {
                getInvoice.IsPaid = true;
                await _residenceInvoicesRepository.UpdateAsync(getInvoice);
                return new BaseResponse(true, "Fatura ödeme başarılı.");
            }
            else
            {
                return new BaseResponse(false, "Hatalı işlem.");
            }
        }
    }
}

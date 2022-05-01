using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.Invoices.GetInvoices
{
    public class GetInvoiceListQueryHandler : IRequestHandler<GetInvoiceListQuery, BaseDataResponse<IReadOnlyList<PaymentDto>>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public GetInvoiceListQueryHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<IReadOnlyList<PaymentDto>>> Handle(GetInvoiceListQuery request, CancellationToken cancellationToken)
        {
            var invoiceList =await _invoiceRepository.GetAllAsync();
            if (invoiceList == null)
                throw new NotFoundException(request);
            var returnList = _mapper.Map<IReadOnlyList<PaymentDto>>(invoiceList);
            return new BaseDataResponse<IReadOnlyList<PaymentDto>>(true,returnList);
        }
    }
}

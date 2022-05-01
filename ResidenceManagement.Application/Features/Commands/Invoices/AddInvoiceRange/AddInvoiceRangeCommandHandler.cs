using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Invoices.AddInvoiceRange
{
    public class AddInvoiceRangeCommandHandler : IRequestHandler<AddInvoiceRangeCommand, BaseResponse>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;
        public AddInvoiceRangeCommandHandler(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddInvoiceRangeCommand request, CancellationToken cancellationToken)
        {

            var checkInvoice = await _invoiceRepository.GetAsync(r => r.Year == request.Year);

            if (checkInvoice != null)
                throw new NotEmptyException(checkInvoice.Year.ToString());
           

            for(int addMonth = 1; addMonth <= 12; addMonth++)
            {
                await _invoiceRepository.AddAsync(new Invoice() { Fee=request.Fee,Year=request.Year,Month = addMonth });
            }
        
            return new BaseResponse(true);
        }
    }
}

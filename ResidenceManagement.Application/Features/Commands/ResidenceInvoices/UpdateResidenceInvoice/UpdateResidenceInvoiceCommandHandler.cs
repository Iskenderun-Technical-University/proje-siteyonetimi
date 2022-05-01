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

namespace ResidenceManagement.Application.Features.Commands.ResidenceInvoices.UpdateResidenceInvoice
{
    public class UpdateResidenceInvoiceCommandHandler : IRequestHandler<UpdateResidenceInvoiceCommand, BaseDataResponse<ResidenceInvoice>>
    {
        private readonly IResidenceInvoiceRepository _residenceInvoiceRepository;
        private readonly IMapper _mapper;

        public UpdateResidenceInvoiceCommandHandler(IResidenceInvoiceRepository residenceInvoiceRepository, IMapper mapper)
        {
            _residenceInvoiceRepository = residenceInvoiceRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<ResidenceInvoice>> Handle(UpdateResidenceInvoiceCommand request, CancellationToken cancellationToken)
        {
            var checkInvoice = await _residenceInvoiceRepository.GetByIdAsync(request.Id);
            if (checkInvoice == null)
                throw new NotFoundException(request);
            
            _mapper.Map(request, checkInvoice, typeof(UpdateResidenceInvoiceCommand), typeof(ResidenceInvoice));
            await _residenceInvoiceRepository.UpdateAsync(checkInvoice);
            return new BaseDataResponse<ResidenceInvoice>(true, checkInvoice);
        }
    }
}

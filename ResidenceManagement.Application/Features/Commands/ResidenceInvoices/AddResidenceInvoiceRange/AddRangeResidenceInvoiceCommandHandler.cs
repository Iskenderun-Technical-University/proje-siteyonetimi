using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceInvoices.AddResidenceInvoiceRange
{
    public class AddRangeResidenceInvoiceCommandHandler : IRequestHandler<AddRangeResidenceInvoiceCommand, BaseResponse>
    {
        private readonly IResidenceInvoiceRepository _residenceInvoiceRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUserResidenceRepository _userResidenceRepository;

        public AddRangeResidenceInvoiceCommandHandler(IResidenceInvoiceRepository residenceInvoiceRepository, IInvoiceRepository invoiceRepository, IMapper mapper, IResidenceRepository residenceRepository, IUserResidenceRepository userResidenceRepository)
        {
            _residenceInvoiceRepository = residenceInvoiceRepository;
            _invoiceRepository = invoiceRepository;
            _userResidenceRepository = userResidenceRepository;
        }

        public async Task<BaseResponse> Handle(AddRangeResidenceInvoiceCommand request, CancellationToken cancellationToken)
        {

            var residenceInvoce = await _residenceInvoiceRepository.GetAllAsync(r => r.Invoice.Year == request.Year);
            if (residenceInvoce.Count != 0)
                throw new NotEmptyException("Toplu fatura girilemez. Fatura bilgisi ekli.");

            var invoiceList =await _invoiceRepository.GetAllAsync(p=>p.Year == request.Year);
            if (invoiceList == null)
                throw new NotFoundException(request);

            var residenceList = await _userResidenceRepository.GetAllAsync(p => p.Residence.IsFull);
            if (residenceList == null)
                throw new NotEmptyException("Boş daire yok.");
            residenceList.ToList().ForEach(residence =>invoiceList.ToList().ForEach((invoice) => {
                var addResidenceInvoice = new ResidenceInvoice();
                addResidenceInvoice.UserResidenceId = residence.ResidenceId;
                addResidenceInvoice.InvoiceId = invoice.Id;
                _residenceInvoiceRepository.AddAsync(addResidenceInvoice);
            }));
            //foreach (var residence in residenceList)
            //{
            //    foreach (var invoice in invoiceList)
            //    {
            //        var addResidenceInvoice = new ResidenceInvoice();
            //        addResidenceInvoice.UserResidenceId = residence.ResidenceId;
            //        addResidenceInvoice.InvoiceId = invoice.Id;
            //        await _residenceInvoiceRepository.AddAsync(addResidenceInvoice);
            //    }

            //}


            return new BaseResponse(true);

        }
    }
}

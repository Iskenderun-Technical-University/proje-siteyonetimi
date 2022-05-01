using MassTransit;
using ResidenceManagement.Application.Contracts.Repositories;
using Shared.Models.Models;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Consumers
{
    public class PaymentConsumer : IConsumer<PaymentShareModel>
    {
        private IResidenceDuesRepository _residenceDuesRepository;
        private IResidenceInvoiceRepository _residenceInvoiceRepository;

        public PaymentConsumer(IResidenceDuesRepository residenceDuesRepository, IResidenceInvoiceRepository residenceInvoiceRepository)
        {
            _residenceDuesRepository = residenceDuesRepository;
            _residenceInvoiceRepository = residenceInvoiceRepository;
        }

        public async Task Consume(ConsumeContext<PaymentShareModel> context)
        {
            //object paymentDetail = null;
            await Task.Run(async () => { 
                var obj = context.Message;
                var paymentType = obj.PaymentType;
              
                if(paymentType == 1)
                {
                    var paymentDetail =await _residenceInvoiceRepository.GetByIdAsync(obj.PaymentId);
                    paymentDetail.IsPaid = true;
                    await _residenceInvoiceRepository.UpdateAsync(paymentDetail);
                }
                if(paymentType == 2)
                {
                    var paymentDetail = await _residenceDuesRepository.GetByIdAsync(obj.PaymentId);
                    paymentDetail.IsPaid = true;
                    await _residenceDuesRepository.UpdateAsync(paymentDetail);
                }

            });
        }
    }
}

using MassTransit;
using MediatR;
using PaymentService.API.Repositories;
using Shared.Models.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentService.API.Features
{
    public class PaymentCommandHandler : IRequestHandler<PaymentCommad, bool>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IBus _busService;


        public PaymentCommandHandler(ICardRepository cardRepository, IBus busService)
        {
            _cardRepository = cardRepository;
            _busService = busService;
        }

        public async Task<bool> Handle(PaymentCommad request, CancellationToken cancellationToken)
        {
            var checkCard = await _cardRepository.GetCardByCardNumber(request.CardNumber);
            if (checkCard == null) return false;
            if(request.LastName != checkCard.LastName && request.FirstName != checkCard.LastName) return false;
            if (request.Fee >= checkCard.Balance) return false;

            var payment = new PaymentShareModel();
            if (payment != null)
            {
                payment.Fee = request.Fee;
                payment.PaymentType = request.PaymentType;
                payment.PaymentId = request.PaymentId;
                Uri uri = new Uri("rabbitmq://localhost/paymentQueue");
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(payment);
      
            }

            return true;
        }
    }
}

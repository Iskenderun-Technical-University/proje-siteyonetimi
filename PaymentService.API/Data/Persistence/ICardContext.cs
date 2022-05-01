using MongoDB.Driver;
using PaymentService.API.Entities;

namespace PaymentService.API.Data.Persistence
{
    public interface ICardContext
    {
        IMongoCollection<Card> Cards { get; }
    }
}

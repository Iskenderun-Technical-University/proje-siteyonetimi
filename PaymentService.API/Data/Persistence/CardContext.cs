using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using PaymentService.API.Entities;

namespace PaymentService.API.Data.Persistence
{
    public class CardContext : ICardContext
    {
        public CardContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Cards = database.GetCollection<Card>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CardContextSeed.SeedData(Cards);
        }
        public IMongoCollection<Card> Cards { get; }
    }
}

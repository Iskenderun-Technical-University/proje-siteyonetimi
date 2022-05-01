using MongoDB.Driver;
using PaymentService.API.Entities;
using System;
using System.Collections.Generic;

namespace PaymentService.API.Data.Persistence
{
    public class CardContextSeed
    {
        public static void SeedData(IMongoCollection<Card> cardCollection)
        {
            bool existCard = cardCollection.Find(p=>true).Any();
            if (!existCard)
            {
                cardCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Card> GetPreconfiguredProducts()
        {
            return new List<Card>()
            {
                new Card()
                {
                    Id = 1,
                    FirstName = "Rıza Can",
                    LastName = "Tire",
                    CardNumber = 12341231,
                    Balance = 10000

                },
                new Card()
                {
                    Id = 2,
                    FirstName = "Ahmet",
                    LastName = "Tire",
                    CardNumber = 12341232,
                    Balance = 10000

                },
                new Card()
                {
                    Id = 3,
                    FirstName = "Yasemin",
                    LastName = "Tire",
                    CardNumber = 12341233,
                    Balance = 10000

                },
                new Card()
                {
                    Id = 4,
                    FirstName = "Hasibe",
                    LastName = "Tire",
                    CardNumber = 12341234,
                    Balance = 10000

                }

            };
        }
    }
}

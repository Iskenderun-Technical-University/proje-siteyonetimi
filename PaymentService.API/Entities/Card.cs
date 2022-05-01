using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PaymentService.API.Entities
{
    public class Card
    {
        [BsonId]
        //[BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
        //[BsonElement("Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CardNumber { get; set; }
        public double Balance { get; set; }
    }
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookingApi.Models
{
    public class AdditionalServices
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string name { get; set; } = null!;

        public string description { get; set; } = null!;

        public string imageUrl { get; set; }

        public string price { get; set; }

        public string availableQty { get; set; }

        public string bookingType { get; set; }

        //user timpstamp und transaktionscode für concurrency management (update) und Errorhandling

    }
}

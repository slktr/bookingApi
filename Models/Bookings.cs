using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookingApi.Models
{
    public class Bookings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string RefName { get; set; } 

        public string bookingDate { get; set; }

        //user timpstamp und transaktionscode für concurrency management (update) und Errorhandling

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookingApi.Services
{
    public class MongoDBBookingService
    {
        private readonly IMongoCollection<Bookings> _bookingsCollection;

        public MongoDBBookingService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _bookingsCollection = database.GetCollection<Bookings>(mongoDBSettings.Value.CollectionName2);
        }

        public async Task<List<Bookings>> GetAsync()
        {
            return await _bookingsCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task<List<Bookings>> GetFilteredAsync(string refName, string bookingDate)
        {
            FilterDefinition<Bookings> filter = Builders<Bookings>.Filter.Eq("RefName", refName) & Builders<Bookings>.Filter.Eq("bookingDate", bookingDate);

            return await _bookingsCollection.Find(filter).ToListAsync();

        }
        public async Task CreateAsync(Bookings bookings)
        {
            await _bookingsCollection.InsertOneAsync(bookings);
            return;
        }
    

    }
}



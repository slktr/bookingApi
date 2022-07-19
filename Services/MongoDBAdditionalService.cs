
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookingApi.Services
{
    public class MongoDBAdditionalService
    {
        private readonly IMongoCollection<AdditionalServices> _additionalServicesCollection;

        public MongoDBAdditionalService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _additionalServicesCollection = database.GetCollection<AdditionalServices>(mongoDBSettings.Value.CollectionName1);
        }

        public async Task<List<AdditionalServices>> GetAsync()
        {
            return await _additionalServicesCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task CreateAsync(AdditionalServices additionalServices)
        {
            await _additionalServicesCollection.InsertOneAsync(additionalServices);
            return;
        }
        public async Task DeleteAsync(string id)
        {
            FilterDefinition<AdditionalServices> filter = Builders<AdditionalServices>.Filter.Eq("Id", id);
            await _additionalServicesCollection.DeleteOneAsync(filter);
            return;
        }

    }
}

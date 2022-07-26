using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoAPI2
{
    public class OrnekService
    {
        private readonly IMongoCollection<Ornek> _OrneksCollection;

        public OrnekService(IOptions<DBSettings> DbSettings)
        {
            var mongoClient = new MongoClient(
                DbSettings.Value.ConnectionString);
          
            var mongoDatabase = mongoClient.GetDatabase(
                DbSettings.Value.DatabaseName);

            _OrneksCollection = mongoDatabase.GetCollection<Ornek>(
                DbSettings.Value.OrnekCollectionName);
        }
        public async Task<List<Ornek>> GetAsync() =>
       await _OrneksCollection.Find(_ => true).ToListAsync();//bütün dataları getirir.

        public async Task<Ornek?> GetAsync(string _id) =>
            await _OrneksCollection.Find(x => x._id == _id).FirstOrDefaultAsync();//tek data getirir.

        public async Task CreateAsync(Ornek newOrnek) =>
            await _OrneksCollection.InsertOneAsync(newOrnek);

        public async Task UpdateAsync(string _id, Ornek updatedOrnek) =>
            await _OrneksCollection.ReplaceOneAsync(x => x._id == _id, updatedOrnek);

        public async Task RemoveAsync(string _id) =>
            await _OrneksCollection.DeleteOneAsync(x => x._id == _id);
    }
}

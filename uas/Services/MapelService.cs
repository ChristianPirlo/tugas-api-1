using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class GuruService
{
    private readonly IMongoCollection<Book> _guruCollection;

    public GuruService(
        IOptions<BookStoreDatabaseSettings> guruStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            guruStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            guruStoreDatabaseSettings.Value.DatabaseName);

        _guruCollection = mongoDatabase.GetCollection<Guru>(
            bookStoreDatabaseSettings.Value.GuruCollectionName);
    }

    public async Task<List<Mapel>> GetAsync() =>
        await _guruCollection.Find(x => true).ToListAsync();

    public async Task<Mapel?> GetAsync(string id) =>
        await _guruCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Mapel newMapel) =>
        await _guruCollection.InsertOneAsync(newMapel);

    public async Task UpdateAsync(string id, Mapel updatedMapel) =>
        await _guruCollection.ReplaceOneAsync(x => x.Id == id, updatedMapel);

    public async Task RemoveAsync(string id) =>
        await _guruCollection.DeleteOneAsync(x => x.Id == id);
}
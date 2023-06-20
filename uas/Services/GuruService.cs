using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class GuruService
{
    private readonly IMongoCollection<Kelas> _guruCollection;

    public GuruService(
        IOptions<BookStoreDatabaseSettings> guruStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            BookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            BookStoreDatabaseSettings.Value.DatabaseName);

        _guruCollection = mongoDatabase.GetCollection<Guru>(
            BookStoreDatabaseSettings.Value.GuruCollectionName);
    }

    public async Task<List<Guru>> GetAsync() =>
        await _guruCollection.Find(x => true).ToListAsync();

    public async Task<Guru?> GetAsync(string nip) =>
        await _guruCollection.Find(x => x.Nip == nip).FirstOrDefaultAsync();

    public async Task CreateAsync(Guru newGuru) =>
        await _guruCollection.InsertOneAsync(newGuru);

    public async Task UpdateAsync(string nip, Guru updatedGuru) =>
        await _guruCollection.ReplaceOneAsync(x => x.Nip == nip, updatedGuru);

    public async Task RemoveAsync(string nip) =>
        await _guruCollection.DeleteOneAsync(x => x.Nip == nip);
}
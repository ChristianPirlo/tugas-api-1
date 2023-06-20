using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class PresensiHarianGuruService
{
    private readonly IMongoCollection<Book> _presensiharianguruCollection;

    public PresensiHarianGuruService(
        IOptions<BookStoreDatabaseSettings> presensiharianguruStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            BookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            BookStoreDatabaseSettings.Value.DatabaseName);

        _guruCollection = mongoDatabase.GetCollection<presensiharianguru>(
            BookStoreDatabaseSettings.Value.GuruCollectionName);
    }

    public async Task<List<presensiharianguru>> GetAsync() =>
        await _presensiharianguruCollection.Find(x => true).ToListAsync();

   public async Task<presensiharianguru?> GetAsync(string nip) =>
        await _presensiharianguruCollection.Find(x => x.Nip == nip).FirstOrDefaultAsync();

    public async Task CreateAsync(presensiharianguru newpresensiharianguru) =>
        await _presensiharianguruCollection.InsertOneAsync(newpresensiharianguru);

    public async Task UpdateAsync(string nip, presensiharianguru updatedpresensiharianguru) =>
        await _presensiharianguruCollection.ReplaceOneAsync(x => x.Nip == nip, updatedGpresensiharianguru);

    public async Task RemoveAsync(string nip) =>
        await _presensiharianguruCollection.DeleteOneAsync(x => x.Nip == nip);
}
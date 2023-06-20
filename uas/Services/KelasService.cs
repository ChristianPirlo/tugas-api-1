using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class KelasService
{
    private readonly IMongoCollection<Kelas> _guruCollection;

    public KelasService(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            BookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            BookStoreDatabaseSettings.Value.DatabaseName);

        _kelasCollection = mongoDatabase.GetCollection<Kelas>(
            bookStoreDatabaseSettings.Value.KelasCollectionName);
    }

    public async Task<List<Kelas>> GetAsync() =>
        await _kelasCollection.Find(x => true).ToListAsync();

    public async Task<Kelas?> GetAsync(string nip) =>
        await _kelasCollection.Find(x => x.Nip == nip).FirstOrDefaultAsync();

    public async Task CreateAsync(Kelas newKelas) =>
        await _kelasCollection.InsertOneAsync(newKelas);

    public async Task UpdateAsync(string nip, Kelas updatedKelas) =>
        await _kelasCollection.ReplaceOneAsync(x => x.Nip == nip, updatedKelas);

    public async Task RemoveAsync(string nip) =>
        await _kelasCollection.DeleteOneAsync(x => x.Nip == nip);
}
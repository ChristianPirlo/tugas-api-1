using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class PresensiHarianGuru
{
    private readonly IMongoCollection<PresensiHarianGuru> _kelasCollection;

    public PresensiHarianGuru(
        IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        _kelasCollection = mongoDatabase.GetCollection<PresensiHarianGuru>(
            bookStoreDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<PresensiHarianGuru>> GetAsync() =>
        await _kelasCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiHarianGuru?> GetAsync(string id) =>
        await _kelasCollection.Find(x => x.Nip == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiHarianGuru newKelas) =>
        await _kelasCollection.InsertOneAsync(newKelas);

    public async Task UpdateAsync(string id, PresensiHarianGuru updatedKelas) =>
        await _kelasCollection.ReplaceOneAsync(x => x.Nip == id, updatedKelas);

    public async Task RemoveAsync(string id) =>
        await _kelasCollection.DeleteOneAsync(x => x.Nip == id);
}
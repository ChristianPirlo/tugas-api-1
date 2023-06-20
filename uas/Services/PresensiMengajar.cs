using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStoreApi.Services;

public class PresensiMengajarService
{
    private readonly IMongoCollection<Book> _presensimengajarCollection;

    public PresensiMengajarService(
        IOptions<BookStoreDatabaseSettings> presensimengajarStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            BookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            BookStoreDatabaseSettings.Value.DatabaseName);

        _presensimengajarCollection = mongoDatabase.GetCollection<>(
            BookStoreDatabaseSettings.Value.PresensiMengajarCollectionName);
    }

    public async Task<List<presensimengajar>> GetAsync() =>
        await _presensimengajarCollection.Find(x => true).ToListAsync();

    public async Task<Presensimengajar?> GetAsync(string nip) =>
        await _guruCollection.Find(x => x.Nip == nip).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiMengajar newpresensimengajar) =>
        await _presensimengajarCollection.InsertOneAsync(newGuru);

    public async Task UpdateAsync(string nip, presensimengajar updatedpresensimengajar) =>
        await _presensimengajarCollection.ReplaceOneAsync(x => x.Nip == nip, updatedpresensimengajar);

    public async Task RemoveAsync(string nip) =>
        await _presensimengajarCollection.DeleteOneAsync(x => x.Nip == nip);
using Gestao.Cadastro.Digital.Domain.Interfaces.Auditoria.Base;
using Gestao.Cadastro.Digital.Infra.MongoDb.Context;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gestao.Cadastro.Digital.Infra.MongoDb.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T>
{
    protected readonly IMongoCollection<T> _collection;

    public BaseRepository(MongoDbContext context, string collectionName)
    {
        _collection = context.GetCollection<T>(collectionName);
    }

    public async Task InsertAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task<T?> GetByIdAsync(ObjectId id)
    {
        var filter = Builders<T>.Filter.Eq("_id", id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}

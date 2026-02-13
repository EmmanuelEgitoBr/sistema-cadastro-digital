using Gestao.Cadastro.Digital.Domain.Entities.BlocoAuditoria;
using Gestao.Cadastro.Digital.Domain.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Infra.MongoDb.Context;
using Gestao.Cadastro.Digital.Infra.MongoDb.Repositories.Base;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Gestao.Cadastro.Digital.Infra.MongoDb.Repositories;

public class AuditoriaRepository : BaseRepository<Auditoria>,
    IAuditoriaRepository
{
    public AuditoriaRepository(MongoDbContext context) : base(context, "Auditoria")
    {
    }

    public async Task<IEnumerable<Auditoria>> GetByUsuarioIdAsync(long usuarioId)
    {
        var filter = Builders<Auditoria>.Filter.Eq(x => x.UsuarioId, usuarioId);

        return await _collection
            .Find(filter)
            .SortByDescending(x => x.Data)
            .ToListAsync();
    }

    public async Task<IEnumerable<Auditoria>> GetByNomeUsuarioAsync(string login)
    {
        var filter = Builders<Auditoria>.Filter.Regex(
            x => x.Login,
            new BsonRegularExpression(login, "i")
        );

        return await _collection
            .Find(filter)
            .SortByDescending(x => x.Data)
            .ToListAsync();
    }
}

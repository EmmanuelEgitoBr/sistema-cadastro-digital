using MongoDB.Bson;

namespace Gestao.Cadastro.Digital.Domain.Interfaces.Auditoria.Base;

public interface IBaseRepository<T>
{
    Task InsertAsync(T entity);
    Task<T?> GetByIdAsync(ObjectId id);
}

using Gestao.Cadastro.Digital.Domain.Interfaces.Auditoria.Base;
using Entidade = Gestao.Cadastro.Digital.Domain.Entities.BlocoAuditoria;

namespace Gestao.Cadastro.Digital.Domain.Interfaces.Auditoria;

public interface IAuditoriaRepository : IBaseRepository<Entidade.Auditoria>
{
    Task<IEnumerable<Entidade.Auditoria>> GetByUsuarioIdAsync(long usuarioId);
    Task<IEnumerable<Entidade.Auditoria>> GetByNomeUsuarioAsync(string nomeUsuario);
}

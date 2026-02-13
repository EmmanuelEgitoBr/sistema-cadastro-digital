using Entidade = Gestao.Cadastro.Digital.Domain.Entities.BlocoAuditoria;

namespace Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;

public interface IAuditoriaService
{
    Task CriarRegistroAuditoriaAsync(Entidade.Auditoria auditoria);
    Task<Entidade.Auditoria> RetornarAuditoriaPorIdAsync(string auditoriaId);
    Task<IEnumerable<Entidade.Auditoria>> RetornarAuditoriaPorUsuarioIdAsync(long usuarioId);
    Task<IEnumerable<Entidade.Auditoria>> RetornarAuditoriaPorLoginAsync(string login);
}

using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;

namespace Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;

public interface IAuditoriaService
{
    Task<string> CriarRegistroAuditoriaAsync(AuditoriaDto auditoria);
    Task<AuditoriaQueryDto?> RetornarAuditoriaPorIdAsync(string auditoriaId);
    Task<IEnumerable<AuditoriaQueryDto>?> RetornarAuditoriaPorUsuarioIdAsync(long usuarioId);
    Task<IEnumerable<AuditoriaQueryDto>?> RetornarAuditoriaPorLoginAsync(string login);
}

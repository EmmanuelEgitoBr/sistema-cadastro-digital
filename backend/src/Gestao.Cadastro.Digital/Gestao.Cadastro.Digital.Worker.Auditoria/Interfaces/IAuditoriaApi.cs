using Gestao.Cadastro.Digital.Worker.Auditoria.Models;
using Refit;

namespace Gestao.Cadastro.Digital.Worker.Auditoria.Interfaces;

public interface IAuditoriaApi
{
    [Post("/api/auditoria")]
    Task SalvarAsync([Body] AuditoriaModel auditoria);
}

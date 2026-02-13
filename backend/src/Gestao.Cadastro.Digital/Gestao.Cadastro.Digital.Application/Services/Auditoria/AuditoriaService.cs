using Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Domain.Interfaces.Auditoria;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestao.Cadastro.Digital.Application.Services.Auditoria;

public class AuditoriaService : IAuditoriaService
{
    private readonly IAuditoriaRepository _auditoriaRepository;

    public AuditoriaService(IAuditoriaRepository auditoriaRepository)
    {
        _auditoriaRepository = auditoriaRepository;
    }

    public async Task CriarRegistroAuditoriaAsync(Domain.Entities.BlocoAuditoria.Auditoria auditoria)
    {
        await _auditoriaRepository.InsertAsync(auditoria);
    }

    public async Task<Domain.Entities.BlocoAuditoria.Auditoria> RetornarAuditoriaPorIdAsync(string auditoriaId)
    {
        var id = ObjectId.Parse(auditoriaId);
        var registro = await _auditoriaRepository.GetByIdAsync(id);
        return registro!;
    }

    public async Task<IEnumerable<Domain.Entities.BlocoAuditoria.Auditoria>> RetornarAuditoriaPorLoginAsync(string login)
    {
        var registros = await _auditoriaRepository.GetByNomeUsuarioAsync(login);
        return registros;
    }

    public async Task<IEnumerable<Domain.Entities.BlocoAuditoria.Auditoria>> RetornarAuditoriaPorUsuarioIdAsync(long usuarioId)
    {
        var registros = await _auditoriaRepository.GetByUsuarioIdAsync(usuarioId);
        return registros;
    }
}

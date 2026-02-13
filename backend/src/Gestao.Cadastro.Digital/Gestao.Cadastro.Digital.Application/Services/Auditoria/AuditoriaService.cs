using Gestao.Cadastro.Digital.Application.DTOs.Auditoria;
using Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Domain.Interfaces.Auditoria;
using MongoDB.Bson;
using Entity = Gestao.Cadastro.Digital.Domain.Entities.BlocoAuditoria;

namespace Gestao.Cadastro.Digital.Application.Services.Auditoria;

public class AuditoriaService : IAuditoriaService
{
    private readonly IAuditoriaRepository _auditoriaRepository;

    public AuditoriaService(IAuditoriaRepository auditoriaRepository)
    {
        _auditoriaRepository = auditoriaRepository;
    }

    public async Task<string> CriarRegistroAuditoriaAsync(AuditoriaDto auditoria)
    {
        var auditoriaEntity = new Entity.Auditoria
        {
            Id = ObjectId.GenerateNewId(),
            Data = DateTime.Now,
            UsuarioId = auditoria.UsuarioId,
            Login = auditoria.Login,
            Acao = auditoria.Acao,
            Entidade = auditoria.Entidade,
            ObjetoAuditoria = auditoria.ObjetoAuditoria
        };

        await _auditoriaRepository.InsertAsync(auditoriaEntity);
        return auditoriaEntity.Id.ToString();
    }

    public async Task<AuditoriaQueryDto?> RetornarAuditoriaPorIdAsync(string auditoriaId)
    {
        var id = ObjectId.Parse(auditoriaId);
        var auditoriaEntity = await _auditoriaRepository.GetByIdAsync(id);

        if (auditoriaEntity == null) return null;

        var auditoriaQuery = new AuditoriaQueryDto
        {
            Data = auditoriaEntity.Data,
            UsuarioId = auditoriaEntity.UsuarioId,
            Login = auditoriaEntity.Login,
            Acao = auditoriaEntity.Acao,
            Entidade = auditoriaEntity.Entidade,
            ObjetoAuditoria = auditoriaEntity.ObjetoAuditoria
        };

        return auditoriaQuery!;
    }

    public async Task<IEnumerable<Domain.Entities.BlocoAuditoria.Auditoria>> RetornarAuditoriaPorUsuarioIdAsync(long usuarioId)
    {
        var registros = await _auditoriaRepository.GetByUsuarioIdAsync(usuarioId);
        return registros;
    }

    public async Task<IEnumerable<AuditoriaQueryDto>?> RetornarAuditoriaPorLoginAsync(string login)
    {
        var listaAuditoriasEntity = await _auditoriaRepository.GetByNomeUsuarioAsync(login);

        if (listaAuditoriasEntity == null) return null;

        var listaAuditorias = new List<AuditoriaQueryDto>();
        foreach (var auditoriaEntity in listaAuditoriasEntity)
        {
            var auditoriaQuery = new AuditoriaQueryDto
            {
                Data = auditoriaEntity.Data,
                UsuarioId = auditoriaEntity.UsuarioId,
                Login = auditoriaEntity.Login,
                Acao = auditoriaEntity.Acao,
                Entidade = auditoriaEntity.Entidade,
                ObjetoAuditoria = auditoriaEntity.ObjetoAuditoria
            };
            listaAuditorias.Add(auditoriaQuery);
        }

        return listaAuditorias;
    }

    async Task<IEnumerable<AuditoriaQueryDto>?> IAuditoriaService.RetornarAuditoriaPorUsuarioIdAsync(long usuarioId)
    {
        var listaAuditoriasEntity = await _auditoriaRepository.GetByUsuarioIdAsync(usuarioId);
        if (listaAuditoriasEntity == null) return null;

        var listaAuditorias = new List<AuditoriaQueryDto>();
        foreach (var auditoriaEntity in listaAuditoriasEntity)
        {
            var auditoriaQuery = new AuditoriaQueryDto
            {
                Data = auditoriaEntity.Data,
                UsuarioId = auditoriaEntity.UsuarioId,
                Login = auditoriaEntity.Login,
                Acao = auditoriaEntity.Acao,
                Entidade = auditoriaEntity.Entidade,
                ObjetoAuditoria = auditoriaEntity.ObjetoAuditoria
            };
            listaAuditorias.Add(auditoriaQuery);
        }
        return listaAuditorias;
    }
}

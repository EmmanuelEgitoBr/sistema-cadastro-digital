using Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;
using Gestao.Cadastro.Digital.Domain.Entities.BlocoAuditoria;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Command = Gestao.Cadastro.Digital.Application.Commands.Auditoria.InserirDadosAuditoriaCommand;

namespace Gestao.Cadastro.Digital.Application.Handlers.Commands.InserirDadosAuditoriaCommand;

internal class InserirDadosAuditoriaCommandHandler :
    IRequestHandler<Command.InserirDadosAuditoriaCommand, string>
{
    private readonly IAuditoriaService _auditoriaService;
    private readonly ILogger<InserirDadosAuditoriaCommandHandler> _logger;

    public InserirDadosAuditoriaCommandHandler(IAuditoriaService auditoriaService,
        ILogger<InserirDadosAuditoriaCommandHandler> logger)
    {
        _auditoriaService = auditoriaService;
        _logger = logger;
    }

    public async Task<string> Handle(Command.InserirDadosAuditoriaCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando o processamento do comando InserirDadosAuditoriaCommand.");

        try
        {
            var auditoria = new Auditoria
            {
                Id = ObjectId.GenerateNewId(),
                Data = DateTime.Now,
                UsuarioId = request.Auditoria.UsuarioId,
                Login = request.Auditoria.Login,
                Acao = request.Auditoria.Acao,
                Entidade = request.Auditoria.Entidade,
                DadosAntes = request.Auditoria.DadosAntes,
                DadosDepois = request.Auditoria.DadosDepois
            };

            await _auditoriaService.CriarRegistroAuditoriaAsync(auditoria);
            _logger.LogInformation("Registro de auditoria criado com sucesso. ID: {AuditoriaId}", auditoria.Id);
            return auditoria.Id.ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar o comando InserirDadosAuditoriaCommand.");
            throw;
        }
    }
}

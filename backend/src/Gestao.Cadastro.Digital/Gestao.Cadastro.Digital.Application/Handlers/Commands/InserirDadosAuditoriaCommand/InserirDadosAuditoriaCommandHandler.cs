using Gestao.Cadastro.Digital.Application.Interfaces.Auditoria;
using MediatR;
using Microsoft.Extensions.Logging;
using Command = Gestao.Cadastro.Digital.Application.Commands.Auditoria.InserirDadosAuditoriaCommand;

namespace Gestao.Cadastro.Digital.Application.Handlers.Commands.InserirDadosAuditoriaCommand;

public class InserirDadosAuditoriaCommandHandler :
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
            var id = await _auditoriaService.CriarRegistroAuditoriaAsync(request.Auditoria);
            _logger.LogInformation("Registro de auditoria criado com sucesso. ID: {AuditoriaId}", id);
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao processar o comando InserirDadosAuditoriaCommand.");
            throw;
        }
    }
}

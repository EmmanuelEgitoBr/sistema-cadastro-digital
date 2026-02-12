using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Gestao.Cadastro.Digital.Application.Commands.InativarPessoaCommand;

public class InativarPessoaCommandHandler : IRequestHandler<InativarPessoaCommand, long>
{
    private readonly IPessoaService _pessoaService;
    private readonly ILogger<InativarPessoaCommandHandler> _logger;

    public InativarPessoaCommandHandler(IPessoaService pessoaService,
        ILogger<InativarPessoaCommandHandler> logger)
    {
        _pessoaService = pessoaService;
        _logger = logger;
    }

    public async Task<long> Handle(InativarPessoaCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando processo de inativação da pessoa com ID: {IdPessoa}",
            request.IdPessoa);
        try
        {
            var idPessoa = await _pessoaService.InativarPessoaAsync(request.IdPessoa);
            _logger.LogInformation("Pessoa com ID: {IdPessoa} inativada com sucesso", idPessoa);
            return idPessoa;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inativar pessoa com ID: {IdPessoa}", request.IdPessoa);
            throw;
        }
    }
}

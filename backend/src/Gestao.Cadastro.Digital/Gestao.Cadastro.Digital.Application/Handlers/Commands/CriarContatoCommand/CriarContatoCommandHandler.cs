using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Command = Gestao.Cadastro.Digital.Application.Commands.CriarContatoCommand;

namespace Gestao.Cadastro.Digital.Application.Handlers.Commands.CriarContatoCommand;

public class CriarContatoCommandHandler : IRequestHandler<Command.CriarContatoCommand, long>
{
    private readonly IPessoaService _pessoaService;
    private readonly ILogger<CriarContatoCommandHandler> _logger;

    public CriarContatoCommandHandler(IPessoaService pessoaService,
        ILogger<CriarContatoCommandHandler> logger)
    {
        _pessoaService = pessoaService;
        _logger = logger;
    }

    public async Task<long> Handle(Command.CriarContatoCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de contato para pessoa com ID: {PessoaId}", request.CriarContatoDto.IdPessoa);

        try
        {
            var idContato = await _pessoaService.InserirContatoPessoaAsync(request.CriarContatoDto);
            _logger.LogInformation("Contato criado com sucesso para pessoa com ID: {PessoaId}, ID do contato: {ContatoId}",
                request.CriarContatoDto.IdPessoa, idContato);
            return idContato;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar contato para pessoa com ID: {PessoaId}",
                request.CriarContatoDto.IdPessoa);
            throw;
        }
    }
}

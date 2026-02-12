using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Command = Gestao.Cadastro.Digital.Application.Commands.CriarEnderecoCommand;

namespace Gestao.Cadastro.Digital.Application.Handlers.Commands.CriarEnderecoCommand;

public class CriarEnderecoCommandHandler : IRequestHandler<Command.CriarEnderecoCommand, long>
{
    private readonly IPessoaService _pessoaService;
    private ILogger<CriarEnderecoCommandHandler> _logger;

    public CriarEnderecoCommandHandler(IPessoaService pessoaService,
        ILogger<CriarEnderecoCommandHandler> logger)
    {
        _pessoaService = pessoaService;
        _logger = logger;
    }

    public async Task<long> Handle(Command.CriarEnderecoCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de endereço para pessoa com ID: {PessoaId}",
            request.CriarEnderecoDto.IdPessoa);

        try
        {
            var idEndereco = await _pessoaService.InserirEnderecoPessoaAsync(request.CriarEnderecoDto);
            _logger.LogInformation("Endereço criado com sucesso para pessoa com ID: {PessoaId}, Endereço ID: {EnderecoId}",
                request.CriarEnderecoDto.IdPessoa, idEndereco);
            return idEndereco;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar endereço para pessoa com ID: {PessoaId}",
                request.CriarEnderecoDto.IdPessoa);
            throw;
        }
    }
}

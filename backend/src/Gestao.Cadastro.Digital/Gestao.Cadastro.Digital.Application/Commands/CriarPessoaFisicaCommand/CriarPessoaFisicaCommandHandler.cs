using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarPessoaFisicaCommand;

public class CriarPessoaFisicaCommandHandler : IRequestHandler<CriarPessoaFisicaCommand, long>
{
    private readonly IPessoaService _pessoaService;
    private readonly ILogger<CriarPessoaFisicaCommandHandler> _logger;

    public CriarPessoaFisicaCommandHandler(IPessoaService pessoaService,
        ILogger<CriarPessoaFisicaCommandHandler> logger)
    {
        _pessoaService = pessoaService;
        _logger = logger;
    }

    public async Task<long> Handle(CriarPessoaFisicaCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de pessoa física - CPF: {Cpf}", request.PessoaFisicaDto.Cpf);

        try
        {
            var idPessoa = await _pessoaService.InserirPessoaFisicaAsync(request.PessoaFisicaDto);

            _logger.LogInformation("Pessoa física criada com sucesso - IdPessoa: {IdPessoa}", idPessoa);

            return idPessoa;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar pessoa física - CPF: {Cpf}", request.PessoaFisicaDto.Cpf);

            throw;
        }
    }
}

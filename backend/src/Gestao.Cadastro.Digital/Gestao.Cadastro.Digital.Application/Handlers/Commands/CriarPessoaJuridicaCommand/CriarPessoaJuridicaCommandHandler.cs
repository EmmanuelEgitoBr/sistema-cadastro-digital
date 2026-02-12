using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Command = Gestao.Cadastro.Digital.Application.Commands.CriarPessoaJuridicaCommand;

namespace Gestao.Cadastro.Digital.Application.Handlers.Commands.CriarPessoaJuridicaCommand;

public class CriarPessoaJuridicaCommandHandler : IRequestHandler<Command.CriarPessoaJuridicaCommand, long>
{
    private readonly IPessoaService _pessoaService;
    private readonly ILogger<CriarPessoaJuridicaCommandHandler> _logger;

    public CriarPessoaJuridicaCommandHandler(IPessoaService pessoaService,
        ILogger<CriarPessoaJuridicaCommandHandler> logger)
    {
        _pessoaService = pessoaService;
        _logger = logger;
    }

    public async Task<long> Handle(Command.CriarPessoaJuridicaCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Iniciando criação de pessoa jurídica - CNPJ: {Cnpj}", 
            request.PessoaJuridicaDto.Cnpj);

        try
        {
            var idPessoa = await _pessoaService.InserirPessoaJuridicaAsync(request.PessoaJuridicaDto);
            _logger.LogInformation("Pessoa jurídica criada com sucesso - ID: {IdPessoa}, CNPJ: {Cnpj}",
                idPessoa, request.PessoaJuridicaDto.Cnpj);

            return idPessoa;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao criar pessoa jurídica - CNPJ: {Cnpj}", request.PessoaJuridicaDto.Cnpj);
            throw;
        }
    }
}

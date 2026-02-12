using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarPessoaFisicaCommand;

public class CriarPessoaFisicaCommandHandler : IRequestHandler<CriarPessoaFisicaCommand, long>
{
    private readonly IPessoaService _pessoaService;

    public CriarPessoaFisicaCommandHandler(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public async Task<long> Handle(CriarPessoaFisicaCommand request, CancellationToken cancellationToken)
    {
        return await _pessoaService.InserirPessoaFisicaAsync(request.PessoaFisicaDto);
    }
}

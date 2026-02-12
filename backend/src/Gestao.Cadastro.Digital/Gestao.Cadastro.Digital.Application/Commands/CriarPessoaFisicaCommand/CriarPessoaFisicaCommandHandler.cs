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

    public Task<long> Handle(CriarPessoaFisicaCommand request, CancellationToken cancellationToken)
    {
        return _pessoaService.InserirPessoaFisicaAsync(request.PessoaFisicaDto);
    }
}

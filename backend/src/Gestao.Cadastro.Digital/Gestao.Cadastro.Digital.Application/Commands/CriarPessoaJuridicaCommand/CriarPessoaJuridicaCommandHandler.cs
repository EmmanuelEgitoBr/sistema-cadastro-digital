using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarPessoaJuridicaCommand;

public class CriarPessoaJuridicaCommandHandler : IRequestHandler<CriarPessoaJuridicaCommand, long>
{
    private readonly IPessoaService _pessoaService;

    public CriarPessoaJuridicaCommandHandler(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public async Task<long> Handle(CriarPessoaJuridicaCommand request, CancellationToken cancellationToken)
    {
        return await _pessoaService.InserirPessoaJuridicaAsync(request.PessoaJuridicaDto);
    }
}

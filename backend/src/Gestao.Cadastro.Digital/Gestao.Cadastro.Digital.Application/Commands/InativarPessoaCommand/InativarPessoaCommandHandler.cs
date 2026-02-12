using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.InativarPessoaCommand;

public class InativarPessoaCommandHandler : IRequestHandler<InativarPessoaCommand, long>
{
    private readonly IPessoaService _pessoaService;

    public InativarPessoaCommandHandler(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public async Task<long> Handle(InativarPessoaCommand request, CancellationToken cancellationToken)
    {
        return await _pessoaService.InativarPessoaAsync(request.IdPessoa);
    }
}

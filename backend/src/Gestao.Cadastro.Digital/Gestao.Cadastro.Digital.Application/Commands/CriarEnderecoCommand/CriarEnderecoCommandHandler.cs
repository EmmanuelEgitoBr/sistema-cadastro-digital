using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarEnderecoCommand;

public class CriarEnderecoCommandHandler : IRequestHandler<CriarEnderecoCommand, long>
{
    private readonly IPessoaService _pessoaService;

    public CriarEnderecoCommandHandler(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public async Task<long> Handle(CriarEnderecoCommand request, CancellationToken cancellationToken)
    {
        return await _pessoaService.InserirEnderecoPessoaAsync(request.CriarEnderecoDto);
    }
}

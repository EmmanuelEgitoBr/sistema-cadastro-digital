using Gestao.Cadastro.Digital.Application.Interfaces;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarContatoCommand;

public class CriarContatoCommandHandler : IRequestHandler<CriarContatoCommand, long>
{
    private readonly IPessoaService _pessoaService;

    public CriarContatoCommandHandler(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    public async Task<long> Handle(CriarContatoCommand request, CancellationToken cancellationToken)
    {
        return await _pessoaService.InserirContatoPessoaAsync(request.CriarContatoDto);
    }
}

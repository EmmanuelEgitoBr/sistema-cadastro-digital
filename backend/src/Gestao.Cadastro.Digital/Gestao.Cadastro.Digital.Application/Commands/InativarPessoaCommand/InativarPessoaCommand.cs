using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.InativarPessoaCommand
{
    public sealed class InativarPessoaCommand(long idPessoa) : IRequest<long>
    {
        public long IdPessoa { get; } = idPessoa;
    }
}
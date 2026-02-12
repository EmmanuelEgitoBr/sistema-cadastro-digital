using Gestao.Cadastro.Digital.Application.DTOs;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarContatoCommand;

public sealed class CriarContatoCommand(CriarContatoDto criarContatoDto) : IRequest<long>
{
    public CriarContatoDto CriarContatoDto { get; } = criarContatoDto;
}

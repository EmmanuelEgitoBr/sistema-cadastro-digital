using Gestao.Cadastro.Digital.Application.DTOs;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarEnderecoCommand;

public sealed class CriarEnderecoCommand(CriarEnderecoDto criarEnderecoDto) : IRequest<long>
{
    public CriarEnderecoDto CriarEnderecoDto { get; } = criarEnderecoDto;
}

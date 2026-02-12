using Gestao.Cadastro.Digital.Application.DTOs;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarPessoaFisicaCommand;

public class CriarPessoaFisicaCommand(CriarPessoaFisicaDto pessoaFisicaDto) : IRequest<long>
{
    public CriarPessoaFisicaDto PessoaFisicaDto { get; } = pessoaFisicaDto;
}

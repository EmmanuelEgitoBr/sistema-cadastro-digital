using Gestao.Cadastro.Digital.Application.DTOs;
using MediatR;

namespace Gestao.Cadastro.Digital.Application.Commands.CriarPessoaJuridicaCommand;

public class CriarPessoaJuridicaCommand(CriarPessoaJuridicaDto pessoaJuridicaDto) : IRequest<long>
{
        public CriarPessoaJuridicaDto PessoaJuridicaDto { get; } = pessoaJuridicaDto;
}

using Gestao.Cadastro.Digital.Application.DTOs;

namespace Gestao.Cadastro.Digital.Application.Interfaces;

public interface IPessoaService
{
    Task<long> InserirPessoaFisicaAsync(CriarPessoaFisicaDto pessoaFisicaDto);
}

using Gestao.Cadastro.Digital.Application.DTOs;

namespace Gestao.Cadastro.Digital.Application.Interfaces;

public interface IPessoaService
{
    Task<long> InserirPessoaFisicaAsync(CriarPessoaFisicaDto pessoaFisicaDto);
    Task<long> InserirPessoaJuridicaAsync(CriarPessoaJuridicaDto pessoaJuridicaDto);
    Task<long> InserirContatoPessoaAsync(CriarContatoDto contatoDto);
    Task<long> InserirEnderecoPessoaAsync(CriarEnderecoDto enderecoDto);
    Task<long> InativarPessoaAsync(long idPessoa);
}

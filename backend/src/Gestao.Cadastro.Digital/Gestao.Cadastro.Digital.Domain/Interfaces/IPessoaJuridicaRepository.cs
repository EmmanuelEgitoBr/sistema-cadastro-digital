using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces.Base;

namespace Gestao.Cadastro.Digital.Domain.Interfaces;

public interface IPessoaJuridicaRepository : IRepository<PessoaJuridica>
{
    Task<PessoaJuridica?> ObterPorPessoaAsync(long idPessoa);
    Task<PessoaJuridica?> ObterPorCnpjAsync(string cnpj);
}

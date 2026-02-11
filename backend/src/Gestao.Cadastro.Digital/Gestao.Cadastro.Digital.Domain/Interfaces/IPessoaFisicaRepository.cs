using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces.Base;

namespace Gestao.Cadastro.Digital.Domain.Interfaces;

public interface IPessoaFisicaRepository : IRepository<PessoaFisica>
{
    Task<PessoaFisica?> ObterPorPessoaAsync(long idPessoa);
    Task<PessoaFisica?> ObterPorCpfAsync(string cpf);
}

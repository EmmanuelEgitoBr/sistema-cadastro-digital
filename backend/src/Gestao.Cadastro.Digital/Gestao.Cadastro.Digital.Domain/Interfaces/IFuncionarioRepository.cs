using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces.Base;

namespace Gestao.Cadastro.Digital.Domain.Interfaces;

public interface IFuncionarioRepository : IRepository<Funcionario>
{
    Task<Funcionario?> ObterPorPessoaAsync(long idPessoa);
}

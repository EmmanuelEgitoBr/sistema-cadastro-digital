using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces.Base;

namespace Gestao.Cadastro.Digital.Domain.Interfaces;

public interface IEnderecoRepository : IRepository<Endereco>
{
    Task<Endereco?> ObterPorPessoaAsync(long idPessoa);
}

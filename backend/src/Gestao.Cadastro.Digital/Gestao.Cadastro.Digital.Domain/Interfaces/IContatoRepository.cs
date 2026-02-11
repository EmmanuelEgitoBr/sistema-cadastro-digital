using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Interfaces.Base;

namespace Gestao.Cadastro.Digital.Domain.Interfaces;

public interface IContatoRepository : IRepository<Contato>
{
    Task<Contato?> ObterPorPessoaAsync(long idPessoa);
}

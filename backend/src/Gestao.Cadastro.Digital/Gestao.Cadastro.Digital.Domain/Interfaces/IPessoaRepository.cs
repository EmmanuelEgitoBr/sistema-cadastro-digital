using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Gestao.Cadastro.Digital.Domain.Interfaces.Base;

namespace Gestao.Cadastro.Digital.Domain.Interfaces;

public interface IPessoaRepository : IRepository<Pessoa>
{
    Task<Pessoa?> ObterCompletoAsync(long idPessoa);
    Task<bool> ExisteDocumentoAsync(string documento);
}
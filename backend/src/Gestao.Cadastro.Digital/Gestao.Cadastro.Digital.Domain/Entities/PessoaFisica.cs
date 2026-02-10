using Gestao.Cadastro.Digital.Domain.Entities.Base;

namespace Gestao.Cadastro.Digital.Domain.Entities;

public class PessoaFisica : Pessoa
{
    public long IdPessoaFisica { get; set; }
    public string? NomePessoa { get; set; }
    public string? Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
}

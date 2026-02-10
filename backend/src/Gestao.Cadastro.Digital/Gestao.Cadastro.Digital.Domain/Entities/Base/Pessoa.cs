using Gestao.Cadastro.Digital.Domain.Enums;

namespace Gestao.Cadastro.Digital.Domain.Entities.Base;

public class Pessoa
{
    public long IdPessoa { get; set; }
    public TipoPessoa TipoPessoa { get; set; }
    public CategoriaPessoa CategoriaPessoa { get; set; }
    public Contato ContatoPessoa { get; set; } = new Contato();
    public Endereco EnderecoPessoa { get; set; } = new Endereco();
    public DateTime DataRegistro { get; set; } = DateTime.Now;
    public DateTime DataInativacao { get; set; }
}
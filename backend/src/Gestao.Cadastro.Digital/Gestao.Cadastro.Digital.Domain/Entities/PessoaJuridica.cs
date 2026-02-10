using Gestao.Cadastro.Digital.Domain.Entities.Base;

namespace Gestao.Cadastro.Digital.Domain.Entities;

public class PessoaJuridica : Pessoa
{
    public long IdPessoaJuridica { get; set; }
    public string? NomeResponsavel { get; set; }
    public string? NomeFantasia { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public string? InscricaoEstadual { get; set; }
    public string? InscricaoMunicipal { get; set; }
    public DateTime DataFundacao { get; set; }
}

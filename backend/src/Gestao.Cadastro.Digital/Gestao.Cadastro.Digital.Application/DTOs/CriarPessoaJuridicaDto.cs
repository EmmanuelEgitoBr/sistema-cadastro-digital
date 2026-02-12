namespace Gestao.Cadastro.Digital.Application.DTOs;

public record CriarPessoaJuridicaDto
{
    public long IdPessoa { get; set; }
    public string? NomeResponsavel { get; set; }
    public string? NomeFantasia { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public string? InscricaoEstadual { get; set; }
    public string? InscricaoMunicipal { get; set; }
    public DateTime DataFundacao { get; set; }
    public string? NaturezaJuridica { get; set; }
    public string? Cnae { get; set; }
    public int CategoriaPessoa { get; set; }
}

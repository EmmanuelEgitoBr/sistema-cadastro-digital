namespace Gestao.Cadastro.Digital.Application.DTOs;

public record CriarPessoaFisicaDto
{
    public long IdPessoa { get; set; }
    public string? NomePessoa { get; set; }
    public string? NomePai { get; set; }
    public string? NomeMae { get; set; }
    public string? Cpf { get; set; }
    public string? NumeroRg { get; set; }
    public string? OrgaoExpedidorRg { get; set; }
    public string? UfExpedidorRg { get; set; }
    public DateTime? DataEmissaoRg { get; set; }
    public string? Sexo { get; set; }
    public string? EstadoCivil { get; set; }
    public string? Nacionalidade { get; set; }
    public string? CidadeNascimento { get; set; }
    public string? UfNascimento { get; set; }
    public DateTime DataNascimento { get; set; }
    public int CategoriaPessoa { get; set; }
}

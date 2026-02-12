using FluentValidation;
using Gestao.Cadastro.Digital.Application.Commands.CriarPessoaJuridicaCommand;

namespace Gestao.Cadastro.Digital.Application.Validators.Commands;

public class CriarPessoaJuridicaCommandValidator : AbstractValidator<CriarPessoaJuridicaCommand>
{
    public CriarPessoaJuridicaCommandValidator()
    {
        RuleFor(x => x.PessoaJuridicaDto.RazaoSocial)
                .NotEmpty().WithMessage("Razão social é obrigatória")
                .MinimumLength(3).WithMessage("Razão social deve conter ao menos 3 caracteres");

        RuleFor(x => x.PessoaJuridicaDto.NomeFantasia)
            .NotEmpty().WithMessage("Nome fantasia é obrigatório");

        RuleFor(x => x.PessoaJuridicaDto.NomeResponsavel)
            .NotEmpty().WithMessage("Nome do responsável é obrigatório");

        RuleFor(x => x.PessoaJuridicaDto.Cnpj)
            .NotEmpty().WithMessage("CNPJ é obrigatório")
            .Must(ValidarCnpj).WithMessage("CNPJ inválido");

        RuleFor(x => x.PessoaJuridicaDto.DataFundacao)
            .NotEmpty().WithMessage("Data de fundação é obrigatória")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Data de fundação não pode ser futura");

        RuleFor(x => x.PessoaJuridicaDto.CategoriaPessoa)
            .GreaterThan(0).WithMessage("Categoria da pessoa é obrigatória");

        RuleFor(x => x.PessoaJuridicaDto.NaturezaJuridica)
            .NotEmpty().WithMessage("Natureza jurídica é obrigatória");

        RuleFor(x => x.PessoaJuridicaDto.Cnae)
            .NotEmpty().WithMessage("CNAE é obrigatório")
            .Must(ValidarCnae).WithMessage("CNAE inválido");

        When(x => !string.IsNullOrWhiteSpace(x.PessoaJuridicaDto.InscricaoMunicipal), () =>
        {
            RuleFor(x => x.PessoaJuridicaDto.InscricaoEstadual)
                .NotEmpty()
                .WithMessage("Inscrição estadual é obrigatória quando houver inscrição municipal");
        });
    }

    private bool ValidarCnpj(string? cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            return false;

        cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

        if (cnpj.Length != 14 || cnpj.Distinct().Count() == 1)
            return false;

        int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var temp = cnpj[..12];
        var soma = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(temp[i].ToString()) * multiplicador1[i];

        var resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        var digito = resto.ToString();
        temp += digito;

        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(temp[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        digito += resto;

        return cnpj.EndsWith(digito);
    }

    private bool ValidarCnae(string? cnae)
    {
        if (string.IsNullOrWhiteSpace(cnae))
            return false;

        // Aceita formatos: 0000-0/00 ou apenas números
        var apenasNumeros = new string(cnae.Where(char.IsDigit).ToArray());

        return apenasNumeros.Length == 7;
    }
}

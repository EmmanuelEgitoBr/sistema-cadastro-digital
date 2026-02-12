using FluentValidation;
using Gestao.Cadastro.Digital.Application.Commands.CriarPessoaFisicaCommand;

namespace Gestao.Cadastro.Digital.Application.Validators.Commands;

public class CriarPessoaFisicaCommandValidator : AbstractValidator<CriarPessoaFisicaCommand>
{
    public CriarPessoaFisicaCommandValidator()
    {
        RuleFor(x => x.PessoaFisicaDto.NomePessoa)
            .NotEmpty().WithMessage("Nome da pessoa é obrigatório")
            .MinimumLength(3).WithMessage("Nome deve conter pelo menos 3 caracteres");

        RuleFor(x => x.PessoaFisicaDto.Cpf)
            .NotEmpty().WithMessage("CPF é obrigatório")
            .Must(ValidarCpf).WithMessage("CPF inválido");

        RuleFor(x => x.PessoaFisicaDto.DataNascimento)
            .NotEmpty().WithMessage("Data de nascimento é obrigatória")
            .LessThan(DateTime.Today).WithMessage("Data de nascimento não pode ser futura");

        RuleFor(x => x.PessoaFisicaDto.Sexo)
            .Must(x => string.IsNullOrEmpty(x) || x == "M" || x == "F")
            .WithMessage("Sexo deve ser M ou F");

        RuleFor(x => x.PessoaFisicaDto.UfNascimento)
            .Length(2).When(x => !string.IsNullOrEmpty(x.PessoaFisicaDto.UfNascimento))
            .WithMessage("UF de nascimento deve conter 2 caracteres");

        RuleFor(x => x.PessoaFisicaDto.UfExpedidorRg)
            .Length(2).When(x => !string.IsNullOrEmpty(x.PessoaFisicaDto.UfExpedidorRg))
            .WithMessage("UF expedidor do RG deve conter 2 caracteres");

        RuleFor(x => x.PessoaFisicaDto.CategoriaPessoa)
            .GreaterThan(0).WithMessage("Categoria da pessoa é obrigatória");

        RuleFor(x => x)
            .Must(x => !string.IsNullOrWhiteSpace(x.PessoaFisicaDto.NomePai) ||
                       !string.IsNullOrWhiteSpace(x.PessoaFisicaDto.NomeMae))
            .WithMessage("Nome do pai ou da mãe deve ser informado");

        When(x => !string.IsNullOrWhiteSpace(x.PessoaFisicaDto.NumeroRg), () =>
        {
            RuleFor(x => x.PessoaFisicaDto.OrgaoExpedidorRg)
                .NotEmpty().WithMessage("Órgão expedidor é obrigatório quando RG for informado");

            RuleFor(x => x.PessoaFisicaDto.UfExpedidorRg)
                .NotEmpty().WithMessage("UF do órgão expedidor é obrigatória quando RG for informado");
        });
    }

    private bool ValidarCpf(string? cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = new string(cpf.Where(char.IsDigit).ToArray());

        if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
            return false;

        int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCpf = cpf.Substring(0, 9);
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        string digito = resto.ToString();
        tempCpf += digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;

        digito += resto;

        return cpf.EndsWith(digito);
    }
}

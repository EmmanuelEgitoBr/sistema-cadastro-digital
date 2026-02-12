using FluentValidation;
using Gestao.Cadastro.Digital.Application.Commands.CriarContatoCommand;

namespace Gestao.Cadastro.Digital.Application.Validators.Commands;

public class CriarContatoCommandValidator : AbstractValidator<CriarContatoCommand>
{
    public CriarContatoCommandValidator()
    {
        RuleFor(x => x.CriarContatoDto.IdPessoa)
            .GreaterThan(0)
            .WithMessage("Id da pessoa é obrigatório");

        RuleFor(x => x.CriarContatoDto.Email)
            .NotEmpty().WithMessage("E-mail é obrigatório")
            .EmailAddress().WithMessage("Formato de e-mail inválido");

        RuleFor(x => x.CriarContatoDto.Telefone)
            .NotEmpty().WithMessage("Telefone é obrigatório")
            .Must(ValidarTelefone)
            .WithMessage("Telefone inválido. Informe DDD + número.");
    }

    private bool ValidarTelefone(string? telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone))
            return false;

        var somenteNumeros = new string(telefone.Where(char.IsDigit).ToArray());

        return somenteNumeros.Length >= 10 && somenteNumeros.Length <= 11;
    }
}

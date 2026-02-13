using FluentValidation;
using Gestao.Cadastro.Digital.Application.Commands.Auth.RegistrarUsuarioCommand;

namespace Gestao.Cadastro.Digital.Application.Validators.Commands;

public class RegistrarUsuarioCommandValidator : AbstractValidator<RegistrarUsuarioCommand>
{
    public RegistrarUsuarioCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().MaximumLength(150);

        RuleFor(x => x.Email)
            .NotEmpty().EmailAddress();

        RuleFor(x => x.Login)
            .NotEmpty().MinimumLength(4);

        RuleFor(x => x.Senha)
            .NotEmpty()
            .MinimumLength(8)
            .Matches("[A-Z]").WithMessage("Senha deve conter letra maiúscula")
            .Matches("[a-z]").WithMessage("Senha deve conter letra minúscula")
            .Matches("[0-9]").WithMessage("Senha deve conter número");

        RuleFor(x => x.Role)
            .NotEmpty();
    }
}

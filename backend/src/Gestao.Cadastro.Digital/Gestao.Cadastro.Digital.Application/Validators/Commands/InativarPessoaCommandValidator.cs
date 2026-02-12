using FluentValidation;
using Gestao.Cadastro.Digital.Application.Commands.InativarPessoaCommand;

namespace Gestao.Cadastro.Digital.Application.Validators.Commands;

public class InativarPessoaCommandValidator : AbstractValidator<InativarPessoaCommand>
{
    public InativarPessoaCommandValidator()
    {
        RuleFor(x => x.IdPessoa)
            .GreaterThan(0).WithMessage("O IdPessoa deve ser maior que zero.");
    }
}

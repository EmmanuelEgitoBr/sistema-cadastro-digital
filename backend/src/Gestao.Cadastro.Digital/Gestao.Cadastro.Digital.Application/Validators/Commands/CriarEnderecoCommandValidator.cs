using FluentValidation;
using Gestao.Cadastro.Digital.Application.Commands.CriarEnderecoCommand;

namespace Gestao.Cadastro.Digital.Application.Validators.Commands;

public class CriarEnderecoCommandValidator : AbstractValidator<CriarEnderecoCommand>
{
    public CriarEnderecoCommandValidator()
    {
        RuleFor(x => x.CriarEnderecoDto.IdPessoa)
            .GreaterThan(0).WithMessage("PessoaId é obrigatório e deve ser maior que zero");
        RuleFor(x => x.CriarEnderecoDto.Logradouro)
            .NotEmpty().WithMessage("Logradouro é obrigatório")
            .MaximumLength(200).WithMessage("Logradouro deve conter no máximo 200 caracteres");
        RuleFor(x => x.CriarEnderecoDto.Numero)
            .NotEmpty().WithMessage("Número é obrigatório")
            .MaximumLength(20).WithMessage("Número deve conter no máximo 20 caracteres");
        RuleFor(x => x.CriarEnderecoDto.Bairro)
            .NotEmpty().WithMessage("Bairro é obrigatório")
            .MaximumLength(100).WithMessage("Bairro deve conter no máximo 100 caracteres");
        RuleFor(x => x.CriarEnderecoDto.Cidade)
            .NotEmpty().WithMessage("Cidade é obrigatória")
            .MaximumLength(100).WithMessage("Cidade deve conter no máximo 100 caracteres");
        RuleFor(x => x.CriarEnderecoDto.Estado)
            .NotEmpty().WithMessage("Estado é obrigatório")
            .MaximumLength(50).WithMessage("Estado deve conter no máximo 50 caracteres");
        RuleFor(x => x.CriarEnderecoDto.Cep)
            .NotEmpty().WithMessage("CEP é obrigatório")
            .Matches(@"^\d{5}-\d{3}$").WithMessage("CEP deve estar no formato XXXXX-XXX");
    }
}

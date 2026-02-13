using FluentValidation;
using Gestao.Cadastro.Digital.Application.Queries.Auditoria.BuscarDadosAuditoriaPorIdQuery;

namespace Gestao.Cadastro.Digital.Application.Validators.Queries;

public class BuscarDadosAuditoriaPorIdQueryValidator : 
    AbstractValidator<BuscarDadosAuditoriaPorIdQuery>
{
    public BuscarDadosAuditoriaPorIdQueryValidator()
    {
        RuleFor(x => x.AuditoriaId)
            .NotEmpty()
            .WithMessage("Id não pode ser vazio");
        
        RuleFor(x => x.AuditoriaId)
            .NotNull()
            .WithMessage("Id não pode ser nulo");
    }
}
using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Cadastro.Digital.Infra.Sql.EntitiesConfiguration;

public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("FUNCIONARIO");

        builder.HasKey(x => x.IdFuncionario);

        builder.Property(x => x.IdFuncionario)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IdPessoa)
            .IsRequired();

        builder.Property(x => x.TipoFuncionario)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Cargo)
            .HasMaxLength(150);

        builder.Property(x => x.Departamento)
            .HasMaxLength(150);

        builder.Property(x => x.DataAdmissao)
            .HasColumnType("date");

        builder.Property(x => x.DataDemissao)
            .HasColumnType("date");

        builder
            .HasOne<Pessoa>()
            .WithOne()
            .HasForeignKey<Funcionario>(x => x.IdPessoa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => x.IdPessoa)
            .IsUnique();
    }
}
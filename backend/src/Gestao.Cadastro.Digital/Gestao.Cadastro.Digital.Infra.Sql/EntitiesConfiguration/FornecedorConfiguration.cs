using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Cadastro.Digital.Infra.Sql.EntitiesConfiguration;

public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
{
    public void Configure(EntityTypeBuilder<Fornecedor> builder)
    {
        builder.ToTable("FORNECEDOR");

        builder.HasKey(x => x.IdFornecedor);

        builder.Property(x => x.IdFornecedor)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IdPessoa)
            .IsRequired();

        builder.Property(x => x.Departamento)
            .HasMaxLength(150);

        builder.Property(x => x.DataInicio)
            .HasColumnType("date");

        builder.Property(x => x.DataFim)
            .HasColumnType("date");

        builder
            .HasOne<Pessoa>()
            .WithOne()
            .HasForeignKey<Fornecedor>(x => x.IdPessoa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => x.IdPessoa)
            .IsUnique();
    }
}
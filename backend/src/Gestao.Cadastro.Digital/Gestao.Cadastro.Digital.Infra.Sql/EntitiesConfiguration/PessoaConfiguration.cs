using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Gestao.Cadastro.Digital.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Cadastro.Digital.Infra.Sql.EntitiesConfiguration;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("PESSOA");

        builder.HasKey(x => x.IdPessoa);

        builder.Property(x => x.IdPessoa)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.TipoPessoa)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.CategoriaPessoa)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.DataRegistro)
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(x => x.DataInativacao)
            .HasColumnType("datetime2");

    }
}
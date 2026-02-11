using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Cadastro.Digital.Infra.Sql.EntitiesConfiguration;

public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
{
    public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
    {
        builder.ToTable("PESSOAJURIDICA");

        builder.Property(x => x.Cnpj)
            .HasMaxLength(14);

        builder.Property(x => x.RazaoSocial)
            .HasMaxLength(250);

        builder.Property(x => x.NomeFantasia)
            .HasMaxLength(250);

        builder.Property(x => x.DataFundacao)
            .HasColumnType("date");

        builder
            .HasOne<Pessoa>()
            .WithOne()
            .HasForeignKey<PessoaJuridica>(x => x.IdPessoa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => x.IdPessoa)
            .IsUnique();
    }
}
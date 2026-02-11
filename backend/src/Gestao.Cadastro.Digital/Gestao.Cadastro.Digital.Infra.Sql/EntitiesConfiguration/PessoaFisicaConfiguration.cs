using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Cadastro.Digital.Infra.Sql.EntitiesConfiguration;

public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisica>
{
    public void Configure(EntityTypeBuilder<PessoaFisica> builder)
    {
        builder.ToTable("PESSOAFISICA");

        builder.Property(x => x.Cpf)
            .HasMaxLength(11);

        builder.Property(x => x.NomePessoa)
            .HasMaxLength(200);

        builder.Property(x => x.DataNascimento)
            .HasColumnType("date");

        builder
            .HasOne<Pessoa>()
            .WithOne()
            .HasForeignKey<PessoaFisica>(x => x.IdPessoa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => x.IdPessoa)
            .IsUnique();
    }
}

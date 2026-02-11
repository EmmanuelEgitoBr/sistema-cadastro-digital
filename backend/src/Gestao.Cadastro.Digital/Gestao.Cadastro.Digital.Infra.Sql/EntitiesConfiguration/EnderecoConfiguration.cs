using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Cadastro.Digital.Infra.Sql.EntitiesConfiguration;

public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("ENDERECO");

        builder.HasKey(x => x.IdEndereco);

        builder.Property(x => x.IdEndereco)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IdPessoa)
            .IsRequired();

        builder.Property(x => x.Bairro)
            .HasMaxLength(50);

        builder.Property(x => x.Logradouro)
            .HasMaxLength(150);

        builder.Property(x => x.Complemento)
            .HasMaxLength(100);

        builder
            .HasOne<Pessoa>()
            .WithOne()
            .HasForeignKey<Endereco>(x => x.IdPessoa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => x.IdPessoa)
            .IsUnique();
    }
}

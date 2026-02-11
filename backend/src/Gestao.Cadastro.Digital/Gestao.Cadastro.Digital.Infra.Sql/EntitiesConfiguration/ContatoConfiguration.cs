using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Cadastro.Digital.Infra.Sql.EntitiesConfiguration;

public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.ToTable("CONTATO");

        builder.HasKey(x => x.IdContato);

        builder.Property(x => x.IdContato)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IdPessoa)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(150);

        builder
            .HasOne<Pessoa>()
            .WithOne()
            .HasForeignKey<Contato>(x => x.IdPessoa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => x.IdPessoa)
            .IsUnique();
    }
}

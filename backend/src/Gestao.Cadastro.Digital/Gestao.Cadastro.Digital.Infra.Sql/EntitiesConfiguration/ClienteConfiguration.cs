using Gestao.Cadastro.Digital.Domain.Entities;
using Gestao.Cadastro.Digital.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gestao.Cadastro.Digital.Infra.Sql.EntitiesConfiguration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("CLIENTE");

        builder.HasKey(x => x.IdCliente);

        builder.Property(x => x.IdCliente)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.IdPessoa)
            .IsRequired();

        builder.Property(x => x.DataInicio)
            .HasColumnType("date");

        builder.Property(x => x.DataFim)
            .HasColumnType("date");

        builder
            .HasOne<Pessoa>()
            .WithOne()
            .HasForeignKey<Cliente>(x => x.IdPessoa)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(x => x.IdPessoa)
            .IsUnique();
    }
}
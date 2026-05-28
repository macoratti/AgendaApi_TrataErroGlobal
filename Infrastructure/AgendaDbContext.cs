using AgendaApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Infrastructure;

public class AgendaDbContext : DbContext
{
    public AgendaDbContext(DbContextOptions<AgendaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contato> Contatos => Set<Contato>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contato>(entity =>
        {
            entity.ToTable("Contatos");

            entity.HasKey(contato => contato.Id);

            entity.Property(contato => contato.Id)
                .ValueGeneratedOnAdd();

            entity.Property(contato => contato.Nome)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(contato => contato.Email)
                .IsRequired()
                .HasMaxLength(254);

            entity.HasIndex(contato => contato.Email)
                .IsUnique();

            entity.Property(contato => contato.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(contato => contato.Sexo)
                .HasConversion<string>()
                .IsRequired();

            entity.Property(contato => contato.DataNascimento)
                .IsRequired(false);

            entity.Property(contato => contato.Status)
                .HasConversion<string>()
                .HasDefaultValue(Status.Ativo)
                .HasSentinel((Status)0)
                .IsRequired();
        });
    }
}

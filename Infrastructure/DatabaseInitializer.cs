using AgendaApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Infrastructure;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AgendaDbContext>();

        await context.Database.EnsureCreatedAsync();

        if (await context.Contatos.AnyAsync())
        {
            return;
        }

        context.Contatos.AddRange(
            new Contato
            {
                Nome = "Ana Silva",
                Email = "ana.silva@email.com",
                Telefone = "11999990001",
                Sexo = Sexo.Feminino,
                DataNascimento = new DateOnly(1990, 5, 12),
                Status = Status.Ativo
            },
            new Contato
            {
                Nome = "Bruno Santos",
                Email = "bruno.santos@email.com",
                Telefone = "21999990002",
                Sexo = Sexo.Masculino,
                DataNascimento = new DateOnly(1985, 9, 23),
                Status = Status.Ativo
            },
            new Contato
            {
                Nome = "Carla Oliveira",
                Email = "carla.oliveira@email.com",
                Telefone = "31999990003",
                Sexo = Sexo.Feminino,
                DataNascimento = new DateOnly(1998, 2, 4),
                Status = Status.Inativo
            });

        await context.SaveChangesAsync();
    }
}

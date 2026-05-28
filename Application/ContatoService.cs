using System.Net.Mail;
using AgendaApi.Domain;
using AgendaApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AgendaApi.Application;

public class ContatoService : IContatoService
{
    private readonly AgendaDbContext _context;

    public ContatoService(AgendaDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Contato>> ObterTodosAsync()
    {
        return await _context.Contatos
            .AsNoTracking()
            .OrderBy(contato => contato.Nome)
            .ToListAsync();
    }

    public async Task<Contato> ObterPorIdAsync(int id)
    {
        var contato = await _context.Contatos
            .AsNoTracking()
            .FirstOrDefaultAsync(contato => contato.Id == id);

        return contato ?? throw new KeyNotFoundException("Contato nao encontrado.");
    }

    public async Task<Contato> CriarAsync(ContatoRequest request)
    {
        ValidarContato(request);

        var email = NormalizarEmail(request.Email);
        await ValidarEmailDuplicadoAsync(email);

        var contato = new Contato
        {
            Nome = request.Nome!.Trim(),
            Email = email,
            Telefone = request.Telefone!.Trim(),
            Sexo = request.Sexo,
            DataNascimento = request.DataNascimento,
            Status = request.Status ?? Status.Ativo
        };

        _context.Contatos.Add(contato);
        await _context.SaveChangesAsync();

        return contato;
    }

    public async Task AtualizarAsync(int id, ContatoRequest request)
    {
        ValidarContato(request);

        var contato = await _context.Contatos.FindAsync(id)
            ?? throw new KeyNotFoundException("Contato nao encontrado.");

        var email = NormalizarEmail(request.Email);
        await ValidarEmailDuplicadoAsync(email, id);

        contato.Nome = request.Nome!.Trim();
        contato.Email = email;
        contato.Telefone = request.Telefone!.Trim();
        contato.Sexo = request.Sexo;
        contato.DataNascimento = request.DataNascimento;
        contato.Status = request.Status ?? Status.Ativo;

        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(int id)
    {
        var contato = await _context.Contatos.FindAsync(id)
            ?? throw new KeyNotFoundException("Contato nao encontrado.");

        _context.Contatos.Remove(contato);
        await _context.SaveChangesAsync();
    }

    private static void ValidarContato(ContatoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
        {
            throw new ArgumentException("O nome e obrigatorio.");
        }

        if (request.Nome.Trim().Length > 150)
        {
            throw new ArgumentException("O nome deve ter no maximo 150 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            throw new ArgumentException("O e-mail e obrigatorio.");
        }

        if (!EmailValido(request.Email))
        {
            throw new ArgumentException("O e-mail informado e invalido.");
        }

        if (string.IsNullOrWhiteSpace(request.Telefone))
        {
            throw new ArgumentException("O telefone e obrigatorio.");
        }

        if (request.Telefone.Trim().Length > 20)
        {
            throw new ArgumentException("O telefone deve ter no maximo 20 caracteres.");
        }

        if (!Enum.IsDefined(request.Sexo))
        {
            throw new ArgumentException("O sexo informado e invalido.");
        }

        if (request.Status.HasValue && !Enum.IsDefined(request.Status.Value))
        {
            throw new ArgumentException("O status informado e invalido.");
        }

        if (request.DataNascimento.HasValue && request.DataNascimento.Value > DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ArgumentException("A data de nascimento nao pode ser futura.");
        }
    }

    private async Task ValidarEmailDuplicadoAsync(string email, int? contatoId = null)
    {
        var existe = await _context.Contatos.AnyAsync(contato =>
            contato.Email == email && (!contatoId.HasValue || contato.Id != contatoId.Value));

        if (existe)
        {
            throw new InvalidOperationException("Ja existe um contato cadastrado com este e-mail.");
        }
    }

    private static string NormalizarEmail(string? email)
    {
        return email!.Trim().ToLowerInvariant();
    }

    private static bool EmailValido(string email)
    {
        try
        {
            var endereco = new MailAddress(email);
            return endereco.Address == email.Trim();
        }
        catch
        {
            return false;
        }
    }
}

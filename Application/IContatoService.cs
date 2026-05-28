using AgendaApi.Domain;

namespace AgendaApi.Application;

public interface IContatoService
{
    Task<IReadOnlyList<Contato>> ObterTodosAsync();

    Task<Contato> ObterPorIdAsync(int id);

    Task<Contato> CriarAsync(ContatoRequest request);

    Task AtualizarAsync(int id, ContatoRequest request);

    Task RemoverAsync(int id);
}

using AgendaApi.Domain;

namespace AgendaApi.Application;

public record ContatoRequest(
    string? Nome,
    string? Email,
    string? Telefone,
    Sexo Sexo,
    DateOnly? DataNascimento,
    Status? Status);

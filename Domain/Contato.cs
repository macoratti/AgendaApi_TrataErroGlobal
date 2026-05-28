namespace AgendaApi.Domain;

public class Contato
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public Sexo Sexo { get; set; }

    public DateOnly? DataNascimento { get; set; }

    public Status Status { get; set; } = Status.Ativo;
}

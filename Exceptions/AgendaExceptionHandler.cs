using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Exceptions;

public class AgendaExceptionHandler : IExceptionHandler
{
    private readonly ILogger<AgendaExceptionHandler> _logger;

    public AgendaExceptionHandler(
        ILogger<AgendaExceptionHandler> logger)
        => _logger = logger;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // Mapeia a exceção para status HTTP + título
        var (status, titulo) = exception switch
        {
            KeyNotFoundException =>
                (404, "Recurso não encontrado"),

            InvalidOperationException =>
                (409, "Conflito de operação"),

            ArgumentException =>
                (400, "Requisição inválida"),

            _ =>
                (500, "Erro interno do servidor")
        };


        // Log estruturado — nível varia conforme a gravidade
        if (status == 500)
        {
            _logger.LogError(
                exception,
                "Erro inesperado: {Mensagem}",
                exception.Message);
        }
        else
        {
            _logger.LogWarning(
                "Exceção tratada [{Status}]: {Mensagem}",
                status,
                exception.Message);
        }

        // Monta a resposta ProblemDetails
        var problem = new ProblemDetails
        {
            Status = status,
            Title = titulo,
            Detail = exception.Message,
            Instance = httpContext.Request.Path
        };

        httpContext.Response.ContentType = "application/problem+json";
        httpContext.Response.StatusCode = status;

        await httpContext.Response.WriteAsJsonAsync(
            problem,
            cancellationToken);

        // true = exceção foi tratada
        return true;
    }
}

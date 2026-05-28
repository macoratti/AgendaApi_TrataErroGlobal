using AgendaApi.Application;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.API;

[ApiController]
[Route("api/[controller]")]
public class ContatosController : ControllerBase
{
    private readonly IContatoService _contatoService;

    public ContatosController(IContatoService contatoService)
    {
        _contatoService = contatoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodosAsync()
    {
            var contatos = await _contatoService.ObterTodosAsync();
            return Ok(contatos);
    }

    [HttpGet("{id:int}", Name = "ObterContatoPorId")]
    public async Task<IActionResult> ObterPorIdAsync(int id)
    {
            var contato = await _contatoService.ObterPorIdAsync(id);
            return Ok(contato);
    }

    [HttpPost]
    public async Task<IActionResult> CriarAsync(ContatoRequest request)
    {
            var contato = await _contatoService.CriarAsync(request);
            return CreatedAtRoute("ObterContatoPorId", new { id = contato.Id }, contato);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> AtualizarAsync(int id, ContatoRequest request)
    {
            await _contatoService.AtualizarAsync(id, request);
            return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoverAsync(int id)
    {
            await _contatoService.RemoverAsync(id);
            return NoContent();
    }

    [HttpGet("debug/erro-nao-tratado")]
    public IActionResult SimularErroNaoTratado()
    {
        throw new Exception("Excecao nao tratada para teste.");
    }
}

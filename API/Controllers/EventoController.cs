using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API;

[ApiController]
[Route("api/evento")]
public class EventoController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public EventoController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
    private static List<Evento> eventos = new List<Evento>();

    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Evento> eventos = _ctx.Eventos.Include(x => x.ONG).ToList();
            return eventos.Count == 0 ? NotFound() : Ok(eventos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        try
        {
            Evento? eventoCadastrado =
                _ctx.Eventos
                .Include(x => x.ONG)
                .FirstOrDefault(x => x.Nome == nome);
            if (eventoCadastrado != null)
            {
                return Ok(eventoCadastrado);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //POST: api/evento/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Evento evento)
    {
        try
        {
            ONG? ong =
                _ctx.ONGs.Find(evento.ONGId);
            if (ong == null)
            {
                return NotFound();
            }
            evento.ONG = ong;
            _ctx.Eventos.Add(evento);
            _ctx.SaveChanges();
            return Created("", evento);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        try
        {
            Evento? eventoCadastrado = _ctx.Eventos.Find(id);
            if (eventoCadastrado != null)
            {
                _ctx.Eventos.Remove(eventoCadastrado);
                _ctx.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //PUT: api/evento/atualizar/{id}
    [HttpPut]
    [Route("atualizar/{id}")]
    public IActionResult Atualizar([FromRoute] int id, [FromBody] Evento eventoAtualizado)
    {
        try
        {
            Evento? eventoExistente = _ctx.Eventos.Find(id);

            if (eventoExistente == null)
            {
                return NotFound();
            }

            eventoExistente.Nome = eventoAtualizado.Nome;
            eventoExistente.Descricao = eventoAtualizado.Descricao;
            eventoExistente.ONGId = eventoAtualizado.ONGId;
            eventoExistente.DataEvento = eventoAtualizado.DataEvento;

            // Salve as alterações no banco de dados
            _ctx.SaveChanges();

            return Ok(eventoExistente);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

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

    //GET: api/evento/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        List<Evento> eventos = _ctx.Eventos.ToList();
        return eventos.Count == 0 ? NotFound() : Ok(eventos);
    }
    //_ctx.Eventos.ToList().Count == 0 ? NotFound() : Ok(_ctx.Eventos.ToList());

    //GET: api/evento/buscar/{bolacha}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        // AppDataContext context = new AppDataContext();
        // context.
        foreach (Evento eventoCadastrado in _ctx.Eventos.ToList())
        {
            if (eventoCadastrado.Nome == nome)
            {
                return Ok(eventoCadastrado);
            }
        }
        return NotFound();
    }

    //POST: api/evento/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Evento evento)
    {
        _ctx.Eventos.Add(evento);
        _ctx.SaveChanges();
        return Created("", evento);
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        //Utilizar o FirstOrDefault com a Expressão lambda
        Evento evento = _ctx.Eventos.Find(id);
        if (evento == null)
        {
            return NotFound();
        }
        _ctx.Eventos.Remove(evento);
        _ctx.SaveChanges();
        return Ok(evento);
    }

}

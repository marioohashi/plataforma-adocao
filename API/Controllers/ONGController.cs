using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/ong")]
public class ONGController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public ONGController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
    private static List<ONG> ongs = new List<ONG>();

    //GET: api/ong/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        List<ONG> ongs = _ctx.ONGs.ToList();
        return ongs.Count == 0 ? NotFound() : Ok(ongs);
    }
    //_ctx.ONGs.ToList().Count == 0 ? NotFound() : Ok(_ctx.ONGs.ToList());

    //GET: api/ong/buscar/{bolacha}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        // AppDataContext context = new AppDataContext();
        // context.
        foreach (ONG ongCadastrado in _ctx.ONGs.ToList())
        {
            if (ongCadastrado.Nome == nome)
            {
                return Ok(ongCadastrado);
            }
        }
        return NotFound();
    }

    //POST: api/ong/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] ONG ong)
    {
        _ctx.ONGs.Add(ong);
        _ctx.SaveChanges();
        return Created("", ong);
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        //Utilizar o FirstOrDefault com a Expressão lambda
        ONG ong = _ctx.ONGs.Find(id);
        if (ong == null)
        {
            return NotFound();
        }
        _ctx.ONGs.Remove(ong);
        _ctx.SaveChanges();
        return Ok(ong);
    }

}

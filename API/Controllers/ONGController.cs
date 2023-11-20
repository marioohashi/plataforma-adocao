using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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
        try
        {
            List<ONG> ongs = _ctx.ONGs.ToList();
            return Ok(ongs);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //GET: api/ong/buscar/{bolacha}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        try
        {
            ONG? ongCadastrada =
                _ctx.ONGs
                .FirstOrDefault(x => x.Nome == nome);
            if (ongCadastrada != null)
            {
                return Ok(ongCadastrada);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET: api/ong/buscar/{id}
    [HttpGet]
    [Route("buscarid/{id}")]
    public IActionResult BuscarId([FromRoute] int id)
    {
        try
        {
            ONG? ongCadastrada = _ctx.ONGs.FirstOrDefault(x => x.ONGId == id);
            if (ongCadastrada != null)
            {
                return Ok(ongCadastrada);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //POST: api/ong/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] ONG ong)
    {
        try
        {
            _ctx.ONGs.Add(ong);
            _ctx.SaveChanges();
            return Created("", ong);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    // PUT: api/ong/atualizar/{id}
    [HttpPut]
    [Route("atualizar/{id}")]
    public IActionResult Atualizar([FromRoute] int id, [FromBody] ONG ongAtualizada)
    {
        try
        {
            ONG ongExistente = _ctx.ONGs.Find(id);

            if (ongExistente == null)
            {
                return NotFound();
            }

            // Atualizar as propriedades da ongExistente com os valores da ongAtualizada

            ongExistente.Nome = ongAtualizada.Nome;
            ongExistente.Missao = ongAtualizada.Missao;
            ongExistente.Historico = ongAtualizada.Historico;
            ongExistente.InformacoesContato = ongAtualizada.InformacoesContato;


            // Adicione outras propriedades que deseja atualizar

            _ctx.SaveChanges();

            return Ok(ongExistente);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }




    [HttpDelete]
    [Route("delete/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        try
        {
            ONG? ongCadastrada = _ctx.ONGs.Find(id);
            if (ongCadastrada != null)
            {
                _ctx.ONGs.Remove(ongCadastrada);
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
}
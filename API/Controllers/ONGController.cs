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

    [HttpPut]
    [Route("atualizar/{id}")]
    public IActionResult AtualizarONG([FromRoute] int id, [FromBody] ONG ongAtualizada)
    {
        try
        {
            ONG ongExistente = _ctx.ONGs.Find(id);
            if (ongExistente == null)
            {
                return NotFound();
            }

            // Atualize as propriedades da ONG existente com as da ONG atualizada
            ongExistente.Nome = ongAtualizada.Nome;
            ongExistente.Missao = ongAtualizada.Missao;
            ongExistente.Historico = ongAtualizada.Historico;
            ongExistente.InformacoesContato = ongAtualizada.InformacoesContato;
            // Adicione aqui outras propriedades que precisam ser atualizadas

            // Salve as alterações no banco de dados
            _ctx.SaveChanges();

            return Ok(ongExistente);
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

    [HttpDelete]
    [Route("deletar/{id}")]
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

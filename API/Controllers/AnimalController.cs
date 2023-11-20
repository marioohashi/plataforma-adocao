using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/animal")]
public class AnimalController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public AnimalController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
    private static List<Animal> animais = new List<Animal>();

    //GET: api/animal/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Animal> animais =
                _ctx.Animais
                .Include(x => x.ONG)
                .ToList();
            return animais.Count == 0 ? NotFound() : Ok(animais);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //GET: api/animal/buscar/{}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        try
        {
            Animal? animalCadastrado =
                _ctx.Animais
                .Include(x => x.ONG)
                .FirstOrDefault(x => x.Nome == nome);
            if (animalCadastrado != null)
            {
                return Ok(animalCadastrado);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // GET: api/animal/buscar/{id}
    [HttpGet]
    [Route("buscarid/{id}")]
    public IActionResult BuscarId([FromRoute] int id)
    {
        try
        {
            Animal? animalCadastrada = _ctx.Animais.FirstOrDefault(x => x.AnimalId == id);
            if (animalCadastrada != null)
            {
                return Ok(animalCadastrada);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    //POST: api/animal/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Animal animal)
    {
        try
        {
            ONG? ong =
                _ctx.ONGs.Find(animal.ONGId);
            if (ong == null)
            {
                return NotFound();
            }
            animal.ONG = ong;
            _ctx.Animais.Add(animal);
            _ctx.SaveChanges();
            return Created("", animal);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }

    //PUT: api/animal/atualizar/{id}
    [HttpPut]
    [Route("atualizar/{id}")]
    public IActionResult Atualizar([FromRoute] int id, [FromBody] Animal animalAtualizado)
    {
        try
        {
            Animal animalExistente = _ctx.Animais.Find(id);
            if (animalExistente == null)
            {
                return NotFound();
            }

            // Atualize as propriedades do animal existente com as do animal atualizado
            animalExistente.Nome = animalAtualizado.Nome;
            animalExistente.Idade = animalAtualizado.Idade;
            animalExistente.Especie = animalAtualizado.Especie;
            animalExistente.Raca = animalAtualizado.Raca;
            animalExistente.Porte = animalAtualizado.Porte;
            animalExistente.Comportamento = animalAtualizado.Comportamento;
            animalExistente.Descricao = animalAtualizado.Descricao;
            animalExistente.Foto = animalAtualizado.Foto;
            animalExistente.Video = animalAtualizado.Video;
            animalExistente.ONGId = animalAtualizado.ONGId;

            // Salve as alterações no banco de dados
            _ctx.SaveChanges();

            return Ok(animalExistente);
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
            Animal? animalCadastrado = _ctx.Animais.Find(id);
            if (animalCadastrado != null)
            {
                _ctx.Animais.Remove(animalCadastrado);
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

internal class HttpUpdateAttribute : Attribute
{
}
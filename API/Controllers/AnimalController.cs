using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API
{
    [ApiController]
    [Route("api/animal")]
    public class AnimalController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        // Construtor da classe. Recebe uma instância de AppDataContext como parâmetro.
        public AnimalController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        // Lista de animais em memória. Nota: Este não é utilizado no código atual e pode ser removido.
        private static List<Animal> animais = new List<Animal>();

    //GET: api/animal/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        List<Animal> animais = _ctx.Animais.ToList();
        return animais.Count == 0 ? NotFound() : Ok(animais);
    }
    //_ctx.Animais.ToList().Count == 0 ? NotFound() : Ok(_ctx.Animais.ToList());

    //GET: api/animal/buscar/{bolacha}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        // AppDataContext context = new AppDataContext();
        // context.
        foreach (Animal animalCadastrado in _ctx.Animais.ToList())
        {
            if (animalCadastrado.Nome == nome)
            {
                return Ok(animalCadastrado);
            }
        }
        return NotFound();
    }

    //POST: api/animal/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Animal animal)
    {
        _ctx.Animais.Add(animal);
        _ctx.SaveChanges();
        return Created("", animal);
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        //Utilizar o FirstOrDefault com a Expressão lambda
        Animal animal = _ctx.Animais.Find(id);
        if (animal == null)
        {
            return NotFound();
        }
        _ctx.Animais.Remove(animal);
        _ctx.SaveChanges();
        return Ok(animal);
    }

    [HttpPost]
    [Route("adicionarVideos/{id}")]
    public IActionResult AdicionarVideos([FromRoute] int id, [FromBody] List<string> videos)
    {
        Animal animal = _ctx.Animais.Find(id);
        if (animal == null)
        {
            return NotFound();
        }

        animal.Videos.AddRange(videos);
        _ctx.SaveChanges();

        return Ok(animal);
    }

    [HttpPost]
    [Route("adicionarFotos/{id}")]
    public IActionResult AdicionarFotos([FromRoute] int id, [FromBody] List<string> fotos)
    {
        Animal animal = _ctx.Animais.Find(id);
        if (animal == null)
        {
            return NotFound();
        }

        animal.Fotos.AddRange(fotos);
        _ctx.SaveChanges();

        return Ok(animal);
    }
}

using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/pessoa")]
public class PessoaController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public PessoaController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
    private static List<Pessoa> pessoas = new List<Pessoa>();

    //GET: api/produto/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        List<Pessoa> pessoas = _ctx.Pessoas.ToList();
        return pessoas.Count == 0 ? NotFound() : Ok(pessoas);
    }
    //_ctx.Pessoas.ToList().Count == 0 ? NotFound() : Ok(_ctx.Pessoas.ToList());

    //GET: api/produto/buscar/{bolacha}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        // AppDataContext context = new AppDataContext();
        // context.
        foreach (Pessoa produtoCadastrado in _ctx.Pessoas.ToList())
        {
            if (produtoCadastrado.Nome == nome)
            {
                return Ok(produtoCadastrado);
            }
        }
        return NotFound();
    }

    //POST: api/produto/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Pessoa produto)
    {
        _ctx.Pessoas.Add(produto);
        _ctx.SaveChanges();
        return Created("", produto);
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        //Utilizar o FirstOrDefault com a Expressão lambda
        Pessoa produto = _ctx.Pessoas.Find(id);
        if (produto == null)
        {
            return NotFound();
        }
        _ctx.Pessoas.Remove(produto);
        _ctx.SaveChanges();
        return Ok(produto);
    }

}

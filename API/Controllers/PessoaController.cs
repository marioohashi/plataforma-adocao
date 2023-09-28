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

    // Função para autenticar uma pessoa (simplificada)
    [HttpPost]
    [Route("autenticar")]
    public IActionResult Autenticar([FromBody] Pessoa pessoa)
    {
        // Implemente sua lógica de autenticação aqui
        // Por exemplo, verifique se o email e senha correspondem a uma pessoa existente
        // Esta é apenas uma implementação simplificada para ilustrar o conceito
        if (_ctx.Pessoas.Any(p => p.Email == pessoa.Email && p.NumeroTelefone == pessoa.NumeroTelefone))
        {
            return Ok(true); // Autenticado com sucesso
        }
        return Unauthorized(); // Falha na autenticação
    }

    // Função para adotar um animal por uma pessoa
    [HttpPost]
    [Route("adotarAnimal")]
    public IActionResult AdotarAnimal([FromBody] Animal animal)
    {
        // Implemente sua lógica de adoção de animal aqui
        // Por exemplo, você pode adicionar o animal à lista de animais adotados pela pessoa
        // Certifique-se de que a classe Pessoa tenha uma propriedade para armazenar os animais adotados
        // Esta é apenas uma implementação simplificada para ilustrar o conceito

        Pessoa pessoa = _ctx.Pessoas.FirstOrDefault(p => p.PessoaId == animal.PessoaId);
        if (pessoa != null)
        {
            pessoa.AdotarAnimal(animal);
            _ctx.SaveChanges();
            return Ok();
        }
        return NotFound(); // Pessoa não encontrada
    }

    // Função para cadastrar um animal por uma pessoa
    [HttpPost]
    [Route("cadastrarAnimal")]
    public IActionResult CadastrarAnimal([FromBody] Animal animal)
    {
        // Implemente sua lógica de cadastro de animal aqui
        // Por exemplo, você pode adicionar o animal à lista de animais cadastrados pela pessoa
        // Certifique-se de que a classe Pessoa tenha uma propriedade para armazenar os animais cadastrados
        // Esta é apenas uma implementação simplificada para ilustrar o conceito
        Pessoa pessoa = _ctx.Pessoas.FirstOrDefault(p => p.PessoaId == animal.PessoaId);
        if (pessoa != null)
        {
            pessoa.CadastrarAnimal(animal);
            _ctx.SaveChanges();
            return Created("", animal);
        }
        return NotFound(); // Pessoa não encontrada
    }
}

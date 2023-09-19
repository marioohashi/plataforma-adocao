﻿using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    private readonly AppDataContext _ctx;

    public ProdutoController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
    private static List<Produto> produtos = new List<Produto>();

    //GET: api/produto/listar
    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        List<Produto> produtos = _ctx.Produtos.ToList();
        return produtos.Count == 0 ? NotFound() : Ok(produtos);
    }
    //_ctx.Produtos.ToList().Count == 0 ? NotFound() : Ok(_ctx.Produtos.ToList());

    //GET: api/produto/buscar/{bolacha}
    [HttpGet]
    [Route("buscar/{nome}")]
    public IActionResult Buscar([FromRoute] string nome)
    {
        // AppDataContext context = new AppDataContext();
        // context.
        foreach (Produto produtoCadastrado in _ctx.Produtos.ToList())
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
    public IActionResult Cadastrar([FromBody] Produto produto)
    {
        _ctx.Produtos.Add(produto);
        _ctx.SaveChanges();
        return Created("", produto);
    }

    [HttpDelete]
    [Route("deletar/{id}")]
    public IActionResult Deletar([FromRoute] int id)
    {
        //Utilizar o FirstOrDefault com a Expressão lambda
        Produto produto = _ctx.Produtos.Find(id);
        if (produto == null)
        {
            return NotFound();
        }
        _ctx.Produtos.Remove(produto);
        _ctx.SaveChanges();
        return Ok(produto);
    }

}

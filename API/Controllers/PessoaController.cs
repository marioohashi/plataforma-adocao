using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API
{
    [ApiController]
    [Route("api/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public PessoaController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        // GET: api/pessoa/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Pessoa> pessoas = _ctx.Pessoas.ToList();
                return pessoas.Count == 0 ? NotFound() : Ok(pessoas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                //GET: api/pessoa/listar
                [HttpGet]
                [Route("listar")]
                public IActionResult Listar()
                {
                    List<Pessoa> pessoas = _ctx.Pessoas.ToList();
                    return pessoas.Count == 0 ? NotFound() : Ok(pessoas);
                }
                //_ctx.Pessoas.ToList().Count == 0 ? NotFound() : Ok(_ctx.Pessoas.ToList());

                //GET: api/pessoa/buscar/{nome}
                [HttpGet]
                [Route("buscar/{nome}")]
                public IActionResult Buscar([FromRoute] string nome)
                {
                    // AppDataContext context = new AppDataContext();
                    // context.
                    foreach (Pessoa pessoaCadastrado in _ctx.Pessoas.ToList())
                    {
                        if (pessoaCadastrado.Nome == nome)
                        {
                            return Ok(pessoaCadastrado);

                        }
                    }


                    // GET: api/pessoa/buscar/{nome}
                    [HttpGet]
                    [Route("buscar/{nome}")]
                    public IActionResult Buscar([FromRoute] string nome)
                    {
                        try
                        {
                            Pessoa? pessoaCadastrada = _ctx.Pessoas.FirstOrDefault(x => x.Nome == nome);
                            if (pessoaCadastrada != null)
                            {
                                return Ok(pessoaCadastrada);
                            }
                            return NotFound();
                        }
                        catch (Exception e)
                        {
                            return BadRequest(e.Message);
                        }
                    }

                    // POST: api/pessoa/cadastrar
                    [HttpPost]
                    [Route("cadastrar")]
                    public IActionResult Cadastrar([FromBody] Pessoa pessoa)
                    {
                        try
                        {
                            _ctx.Pessoas.Add(pessoa);
                            _ctx.SaveChanges();
                            return Created("", pessoa);
                        }
                        catch (Exception e)
                        {
                            return BadRequest(e.Message);
                        }
                    }

                    // DELETE: api/pessoa/deletar/{id}
                    [HttpDelete]
                    [Route("deletar/{id}")]
                    public IActionResult Deletar([FromRoute] int id)
                    {
                        try
                        {
                            Pessoa? pessoaCadastrada = _ctx.Pessoas.Find(id);
                            if (pessoaCadastrada != null)
                            {
                                _ctx.Pessoas.Remove(pessoaCadastrada);
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

                    //PUT: api/pessoa/atualizar/{id}
                    [HttpPut]
                    [Route("atualizar/{id}")]
                    public IActionResult Atualizar([FromRoute] int id, [FromBody] Pessoa pessoaAtualizado)
                    {
                        try
                        {
                            Pessoa? pessoaExistente = _ctx.Pessoas.Find(id);

                            if (pessoaExistente == null)
                            {
                                return NotFound();
                            }

                            pessoaExistente.Nome = pessoaAtualizado.Nome;
                            pessoaExistente.Endereco = pessoaAtualizado.Endereco;
                            pessoaExistente.NumeroTelefone = pessoaAtualizado.NumeroTelefone;
                            pessoaExistente.Email = pessoaAtualizado.Email;

                            // Salve as alterações no banco de dados
                            _ctx.SaveChanges();

                            return Ok(pessoaExistente);
                        }
                        catch (Exception e)
                        {
                            return BadRequest(e.Message);
                        }
                    }
                }
            }
        }
    }
}
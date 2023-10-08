﻿using API.Data;
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

        [HttpPut]
        [Route("atualizar/{id}")]
        public IActionResult AtualizarPessoa([FromRoute] int id, [FromBody] Pessoa pessoaAtualizada)
        {
            try
            {
                Pessoa pessoaExistente = _ctx.Pessoas.Find(id);
                if (pessoaExistente == null)
                {
                    return NotFound();
                }

                // Atualize as propriedades da Pessoa existente com as da Pessoa atualizada
                pessoaExistente.Nome = pessoaAtualizada.Nome;
                pessoaExistente.Endereco = pessoaAtualizada.Endereco;
                pessoaExistente.NumeroTelefone = pessoaAtualizada.NumeroTelefone;
                pessoaExistente.Email = pessoaAtualizada.Email;
                // Adicione aqui outras propriedades que precisam ser atualizadas

                // Salve as alterações no banco de dados
                _ctx.SaveChanges();

                return Ok(pessoaExistente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // DELETE: api/pessoa/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult DeletarPessoa([FromRoute] int id)
        {
            try
            {
                Pessoa pessoa = _ctx.Pessoas.Find(id);
                if (pessoa == null)
                {
                    return NotFound();
                }

                _ctx.Pessoas.Remove(pessoa);
                _ctx.SaveChanges();

                return Ok(pessoa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

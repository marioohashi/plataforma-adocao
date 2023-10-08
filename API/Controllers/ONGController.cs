using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API
{
    [ApiController]
    [Route("api/ong")]
    public class ONGController : ControllerBase
    {
        private readonly AppDataContext _ctx;

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
        //GET: api/ong/listar
        [HttpGet]
        [Route("listar")]

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

        //PUT: api/ong/atualizar/{id}
        [HttpPut]
        [Route("atualizar/{id}")]
        public IActionResult Atualizar([FromRoute] int id, [FromBody] ONG ongAtualizado)
        {
            try
            {
                ONG? ongExistente = _ctx.ONGs.Find(id);

                if (ongExistente == null)
                {
                    return NotFound();
                }

                ongExistente.Nome = ongAtualizado.Nome;
                ongExistente.Missao = ongAtualizado.Missao;
                ongExistente.Historico = ongAtualizado.Historico;
                ongExistente.InformacoesContato = ongAtualizado.InformacoesContato;

                // Salve as alterações no banco de dados
                _ctx.SaveChanges();

                return Ok(ongExistente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
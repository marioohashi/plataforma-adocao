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

<<<<<<< HEAD
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
=======
        // Construtor da classe. Recebe uma instância de AppDataContext como parâmetro.
        public ONGController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        // Lista de ONGs em memória. Nota: Este não é utilizado no código atual e pode ser removido.
        private static List<ONG> ongs = new List<ONG>();

        // Rota para listar todas as ONGs.
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            // Obtém a lista de ONGs do contexto do banco de dados.
            List<ONG> ongs = _ctx.ONGs.ToList();
            // Verifica se a lista está vazia. Se estiver, retorna uma resposta 404 Not Found. 
            // Caso contrário, retorna a lista de ONGs como uma resposta 200 OK.
            return ongs.Count == 0 ? NotFound() : Ok(ongs);
        }

        // Rota para buscar uma ONG por nome.
        [HttpGet]
        [Route("buscar/{nome}")]
        public IActionResult Buscar([FromRoute] string nome)
        {
            // Loop através de todas as ONGs cadastradas.
            foreach (ONG ongCadastrado in _ctx.ONGs.ToList())
            {
                // Se o nome da ONG corresponder ao nome passado na rota, retorna a ONG encontrada.
                if (ongCadastrado.Nome == nome)
                {
                    return Ok(ongCadastrado);
                }
            }
            // Se nenhum match for encontrado, retorna uma resposta 404 Not Found.
            return NotFound();
        }

        // Rota para cadastrar uma nova ONG.
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] ONG ong)
        {
            // Adiciona a nova ONG ao contexto do banco de dados.
            _ctx.ONGs.Add(ong);
            // Salva as mudanças no banco de dados.
            _ctx.SaveChanges();
            // Retorna a ONG criada como uma resposta 201 Created.
            return Created("", ong);
        }

        // Rota para deletar uma ONG por ID.
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            // Busca a ONG pelo ID.
            ONG ong = _ctx.ONGs.Find(id);
            // Se a ONG não for encontrada, retorna uma resposta 404 Not Found.
            if (ong == null)
            {
                return NotFound();
            }
            // Remove a ONG do contexto do banco de dados.
            _ctx.ONGs.Remove(ong);
            // Salva as mudanças no banco de dados.
            _ctx.SaveChanges();
            // Retorna a ONG removida como uma resposta 200 OK.
            return Ok(ong);
        }
>>>>>>> origin/main
    }
}

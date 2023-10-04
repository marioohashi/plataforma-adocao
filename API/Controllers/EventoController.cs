using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [ApiController]
    [Route("api/evento")]
    public class EventoController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        // Construtor da classe. Recebe uma instância de AppDataContext como parâmetro.
        public EventoController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        // Lista de eventos em memória. Nota: Este não é utilizado no código atual e pode ser removido.
        private static List<Evento> eventos = new List<Evento>();

        // Rota para listar todos os eventos.
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            // Obtém a lista de eventos do contexto do banco de dados.
            List<Evento> eventos = _ctx.Eventos.ToList();
            // Verifica se a lista está vazia. Se estiver, retorna uma resposta 404 Not Found. 
            // Caso contrário, retorna a lista de eventos como uma resposta 200 OK.
            return eventos.Count == 0 ? NotFound() : Ok(eventos);
        }

        // Rota para buscar um evento por nome.
        [HttpGet]
        [Route("buscar/{nome}")]
        public IActionResult Buscar([FromRoute] string nome)
        {
            // Loop através de todos os eventos cadastrados.
            foreach (Evento eventoCadastrado in _ctx.Eventos.ToList())
            {
                // Se o nome do evento corresponder ao nome passado na rota, retorna o evento encontrado.
                if (eventoCadastrado.Nome == nome)
                {
                    return Ok(eventoCadastrado);
                }
            }
            // Se nenhum match for encontrado, retorna uma resposta 404 Not Found.
            return NotFound();
        }

        // Rota para cadastrar um novo evento.
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Evento evento)
        {
            // Adiciona o novo evento ao contexto do banco de dados.
            _ctx.Eventos.Add(evento);
            // Salva as mudanças no banco de dados.
            _ctx.SaveChanges();
            // Retorna o evento criado como uma resposta 201 Created.
            return Created("", evento);
        }

        // Rota para deletar um evento por ID.
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            // Busca o evento pelo ID.
            Evento evento = _ctx.Eventos.Find(id);
            // Se o evento não for encontrado, retorna uma resposta 404 Not Found.
            if (evento == null)
            {
                return NotFound();
            }
            // Remove o evento do contexto do banco de dados.
            _ctx.Eventos.Remove(evento);
            // Salva as mudanças no banco de dados.
            _ctx.SaveChanges();
            // Retorna o evento removido como uma resposta 200 OK.
            return Ok(evento);
        }
    }
}

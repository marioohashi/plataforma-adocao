using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

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

        // Rota para listar todos os animais disponíveis para adoção.
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            // Obtém a lista de animais do contexto do banco de dados.
            List<Animal> animais = _ctx.Animais.ToList();
            // Verifica se a lista está vazia. Se estiver, retorna uma resposta 404 Not Found. 
            // Caso contrário, retorna a lista de animais como uma resposta 200 OK.
            return animais.Count == 0 ? NotFound() : Ok(animais);
        }

        // Rota para buscar um animal por nome.
        [HttpGet]
        [Route("buscar/{nome}")]
        public IActionResult Buscar([FromRoute] string nome)
        {
            // Loop através de todos os animais cadastrados.
            foreach (Animal animalCadastrado in _ctx.Animais.ToList())
            {
                // Se o nome do animal corresponder ao nome passado na rota, retorna o animal encontrado.
                if (animalCadastrado.Nome == nome)
                {
                    return Ok(animalCadastrado);
                }
            }
            // Se nenhum match for encontrado, retorna uma resposta 404 Not Found.
            return NotFound();
        }

        // Rota para cadastrar um novo animal.
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Animal animal)
        {
            // Adiciona o novo animal ao contexto do banco de dados.
            _ctx.Animais.Add(animal);
            // Salva as mudanças no banco de dados.
            _ctx.SaveChanges();
            // Retorna o animal criado como uma resposta 201 Created.
            return Created("", animal);
        }

        // Rota para deletar um animal por ID.
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            // Busca o animal pelo ID.
            Animal animal = _ctx.Animais.Find(id);
            // Se o animal não for encontrado, retorna uma resposta 404 Not Found.
            if (animal == null)
            {
                return NotFound();
            }
            // Remove o animal do contexto do banco de dados.
            _ctx.Animais.Remove(animal);
            // Salva as mudanças no banco de dados.
            _ctx.SaveChanges();
            // Retorna o animal removido como uma resposta 200 OK.
            return Ok(animal);
        }

        // Rota para adicionar vídeos a um animal por ID.
        [HttpPost]
        [Route("adicionarVideos/{id}")]
        public IActionResult AdicionarVideos([FromRoute] int id, [FromBody] List<string> videos)
        {
            // // Busca o animal pelo ID.
            // Animal animal = _ctx.Animais.Find(id);
            // // Se o animal não for encontrado, retorna uma resposta 404 Not Found.
            // if (animal == null)
            // {
            //     return NotFound();
            // }

            // // Adiciona os vídeos à lista de vídeos do animal e salva as mudanças no banco de dados.
            // animal.Videos.AddRange(videos);
            // _ctx.SaveChanges();

            // // Retorna o animal atualizado como uma resposta 200 OK.
            // return Ok(animal);
            return Ok();
        }

        // Rota para adicionar fotos a um animal por ID.
        [HttpPost]
        [Route("adicionarFotos/{id}")]
        public IActionResult AdicionarFotos([FromRoute] int id, [FromBody] List<string> fotos)
        {
            // Busca o animal pelo ID.
            // Animal animal = _ctx.Animais.Find(id);
            // // Se o animal não for encontrado, retorna uma resposta 404 Not Found.
            // if (animal == null)
            // {
            //     return NotFound();
            // }

            // // Adiciona as fotos à lista de fotos do animal e salva as mudanças no banco de dados.
            // animal.Fotos.AddRange(fotos);
            // _ctx.SaveChanges();

            // // Retorna o animal atualizado como uma resposta 200 OK.
            // return Ok(animal);
            return Ok();
        }
    }
}

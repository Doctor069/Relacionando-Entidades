using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NET_6_criando_uma_web.Data.Dtos.Movie;
using NET_6_Relacionando_Entidades.Data;
using NET_6_Relacionando_Entidades.Models;

namespace NET_6_Relacionando_Entidades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        //private static List<Filme> filmes = new List<Filme>();  --- no curso foi apagado, sera usado o controlador para fazer que o context seja responsavel de acessar o banco de dados
        //private static int id = 1; // criando ids para os filmes

        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost] //metado de adição para o Swagger
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto) // FromBody - vem do corpo da inquisição
        {
            //filme.Id = id++; // mudando ids dos filmes
            //filmes.Add(filme); --- apagado e sera usado o context
            
            //automapper
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.IdFilme);

            return CreatedAtAction(nameof(RecuperarFilmeId), new { _id = filme.IdFilme }, filme);
        }


        [HttpGet] //pegar ou ler Http / consumir
        public IEnumerable<ReadFilmeDto> LerFilmes([FromQuery] int skip = 0, [FromQuery] int take = 60, [FromQuery] string? nomeCinema = null) // IEnumerable - retorna um enumunbelavel de lista generica
        {
            if(nomeCinema == null)
            {
                return _mapper.Map<List<ReadFilmeDto>>
                    (_context.Filmes.Skip(skip)
                        .Take(take).ToList()); // Skip - pula determinada quantidade - Take - pega determinada quantidade
                                               //enves de retornar apenas --- filmes ---, sera retornado o context
            }
            return _mapper.Map<List<ReadFilmeDto>>
                    (_context.Filmes.Skip(skip)
                        .Take(take).Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.NomeCinema == nomeCinema)).ToList());

        }


        [HttpGet("{_idFilme}")] // badding automatico
        public IActionResult RecuperarFilmeId(int _idFilme) // ? -- pode ser ou nao nulo // IActionResult - é not found ou ok o retorno
        {
            var filme = _context.Filmes.FirstOrDefault(filmes => filmes.IdFilme == _idFilme);  // expressao lambda
            //enves de retornar apenas --- filmes ---, sera retornado o context
            if (filme == null)
            {
                return NotFound();
            }

            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

            return Ok(filmeDto);
        }

        [HttpPut("{_idFilme}")]
        public IActionResult AtualizaFilme(int _id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.IdFilme == _id);

            if (filme == null) return NotFound();

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{_idFilme}")]
        public IActionResult AtualizaFilmePatch(int _id, JsonPatchDocument<UpdateFilmeDto> patch)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.IdFilme == _id);

            if (filme == null) return NotFound();

            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

            patch.ApplyTo(filmeParaAtualizar, ModelState);

            if (!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(filmeParaAtualizar, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{_idFilme}")]
        public IActionResult DeletaFilme(int _id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.IdFilme == _id);

            if (filme == null) return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

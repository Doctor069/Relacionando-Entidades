using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NET_6_criando_uma_web.Data.Dtos.Movie_theater;
using NET_6_criando_uma_web.Models.Movie_theater;
using NET_6_Relacionando_Entidades.Data;

namespace NET_6_criando_uma_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { IdCinema = cinema.IdCinema }, cinemaDto);
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> RecuperaCinemas([FromQuery]int? enderecoId = null)
        {
            if(enderecoId == null)
            {
                return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
            }
            return _mapper.Map < List<ReadCinemaDto>>(_context.Cinemas.FromSql($"SELECT Id, Nome, EnderecoId From cinemas where cinemas.EnderecoId = {enderecoId}").ToList());
        }

        [HttpGet("{_idCinema}")]
        public IActionResult RecuperaCinemasPorId(int _idCinema)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.IdCinema == _idCinema);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{_idCinema}")]
        public IActionResult AtualizaCinema(int _idCinema, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.IdCinema == _idCinema);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{_idCinema}")]
        public IActionResult DeletaCinema(int _idCinema)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.IdCinema == _idCinema);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

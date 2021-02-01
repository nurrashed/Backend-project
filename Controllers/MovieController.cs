using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _context;
        private readonly IMapper _mapper;
        public MovieController(MovieContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetMovies(){
            //List<Movie> movies = await _context.Movies.Include(f =>f.OrderDetails).ToListAsync();
            List<Movie> movies = await _context.Movies.ToListAsync();

            List<MovieDTO> movieDTOs = _mapper.Map<List<MovieDTO>>(movies);

            return Ok(movieDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetMovieById(int id){
            //// Movie found = await _context.Movies.Include(f=>f.OrderDetails).FirstOrDefaultAsync(f=>f.Id == id);
            Movie found = await _context.Movies.FirstOrDefaultAsync(f=>f.Id == id);

            if(found == null){
                return NotFound();
            }
            return Ok(_mapper.Map<MovieDTO>(found));
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovie(MovieDTO newMovieDTO){
            Movie newMovie = _mapper.Map<Movie>(newMovieDTO);
            _context.Movies.Add(newMovie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateMovie", newMovie);
        }
        

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie){
            if(id != movie.Id){
                return BadRequest();
            }
            _context.Entry(movie).State = EntityState.Modified;

            try{
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                if(!MovieExists(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return Ok(_mapper.Map<MovieDTO>(movie));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e=> e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id){
            Movie found = await _context.Movies.FindAsync(id);
            if(found == null){
                return NotFound();
            }
            _context.Movies.Remove(found);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

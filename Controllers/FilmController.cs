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
    public class FilmController : ControllerBase
    {
        private readonly FilmContext _context;
        private readonly IMapper _mapper;
        public FilmController(FilmContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetFilms(){
            List<Film> films = await _context.Films.Include(f =>f.OrderDetails).ToListAsync();

            List<FilmDTO> filmDTOs = _mapper.Map<List<FilmDTO>>(films);

            return Ok(filmDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetFilmById(int id){
            Film found = await _context.Films.Include(f=>f.OrderDetails).FirstOrDefaultAsync(f=>f.Id == id);

            if(found == null){
                return NotFound();
            }
            return Ok(_mapper.Map<FilmDTO>(found));
        }

        [HttpPost]
        public async Task<ActionResult> CreateFilm(FilmDTO newFilmDTO){
            Film newFilm = _mapper.Map<Film>(newFilmDTO);
            _context.Films.Add(newFilm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("CreateFilm", newFilm);
        }
        /* public async Task<ActionResult> CreateFilm(Film newFilm){
            _context.Films.Add(newFilm);
            await _context.SaveChangesAsync();
            return CreatedAtAction("CreateFilm", newFilm);
        } */

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFilm(int id, Film film){
            if(id != film.Id){
                return BadRequest();
            }
            _context.Entry(film).State = EntityState.Modified;

            try{
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException){
                if(!FilmExists(id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }
            return Ok(_mapper.Map<FilmDTO>(film));
        }

        private bool FilmExists(int id)
        {
            return _context.Films.Any(e=> e.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFilm(int id){
            Film found = await _context.Films.FindAsync(id);
            if(found == null){
                return NotFound();
            }
            _context.Films.Remove(found);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

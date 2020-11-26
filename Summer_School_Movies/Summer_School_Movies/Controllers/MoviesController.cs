using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summer_School_Movies.Models;

namespace Summer_School_Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies.Include(m => m.topActors).ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            var movie = await _context.Movies.Include(o => o.topActors).FirstOrDefaultAsync(x => x.movieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // GET: api/Movies/query
        [HttpGet]
        [Route("Search")]
        //https://localhost:5001/api/Movies?query=up
        public async Task<ActionResult<IEnumerable<Movie>>> SearchMovies(string query)
        {
            string query1 = query;
            string query2 = char.ToUpper(query[0]) + query.Substring(1);

            List<Movie> movie = await _context.Movies.Include(m => m.topActors).Where(x => x.movieName.Contains(query1) || x.movieName.Contains(query2)).ToListAsync();

            if(movie.Count == 0)
            {
                movie = await _context.Movies.Include(m => m.topActors).Where(c => c.topActors.Any(m => m.actorName.Contains(query1) || m.actorName.Contains(query2))).ToListAsync();
            }
            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            Movie mUpdate = _context.Movies.Include(c=>c.topActors).FirstOrDefault(t => t.movieId == id);
            if (mUpdate != null)
            { 
                mUpdate.movieName = movie.movieName;
                mUpdate.description = movie.description;
                mUpdate.movieGenre = movie.movieGenre;
                mUpdate.releaseDate = movie.releaseDate;
                mUpdate.ageRestriction = movie.ageRestriction;

                if(movie.topActors.Count > mUpdate.topActors.Count)
                {
                    for (int j = 0; j < movie.topActors.Count; j++)
                    {
                        if (j < mUpdate.topActors.Count)
                        {
                            mUpdate.topActors.ElementAt(j).actorName = movie.topActors.ElementAt(j).actorName;
                        }
                        else
                        {
                            mUpdate.topActors.Add(movie.topActors.ElementAt(j));
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < mUpdate.topActors.Count; j++)
                    {
                            mUpdate.topActors.ElementAt(j).actorName = movie.topActors.ElementAt(j).actorName;
                    }
                }
                              
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetMovie", new { id = movie.movieId }, movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.movieId }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.movieId == id);
        }
    }
}

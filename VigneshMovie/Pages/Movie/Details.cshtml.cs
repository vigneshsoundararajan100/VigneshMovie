using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VigneshMovie.Data;
using VigneshMovie.Model;

namespace VigneshMovie.Pages.Movie
{
    public class DetailsModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public DetailsModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

       public Movies Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            


            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
            Movie.MovieActor = await _context.MovieActor
                .Where(s => s.MovieId == id)
                 .Include(m => m.Actor)
                 .Include(m => m.Movies).ToListAsync();

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

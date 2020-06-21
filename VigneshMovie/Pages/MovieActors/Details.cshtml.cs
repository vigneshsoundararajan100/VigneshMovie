using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VigneshMovie.Data;
using VigneshMovie.Model;

namespace VigneshMovie.Pages.MovieActors
{
    public class DetailsModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public DetailsModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

        public MovieActor MovieActor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieActor = await _context.MovieActor
                .Include(m => m.Actor)
                .Include(m => m.Movies).FirstOrDefaultAsync(m => m.ActorId == id);

            if (MovieActor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

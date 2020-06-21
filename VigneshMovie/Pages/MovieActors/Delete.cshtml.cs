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
    public class DeleteModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public DeleteModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieActor = await _context.MovieActor.FindAsync(id);

            if (MovieActor != null)
            {
                _context.MovieActor.Remove(MovieActor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

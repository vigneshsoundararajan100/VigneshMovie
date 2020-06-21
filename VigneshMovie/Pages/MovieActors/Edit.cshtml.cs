using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VigneshMovie.Data;
using VigneshMovie.Model;

namespace VigneshMovie.Pages.MovieActors
{
    public class EditModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public EditModel(VigneshMovie.Data.VigneshMovieContext context)
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
           ViewData["ActorId"] = new SelectList(_context.Actor, "ActorId", "ActorId");
           ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieActorExists(MovieActor.ActorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieActorExists(int id)
        {
            return _context.MovieActor.Any(e => e.ActorId == id);
        }
    }
}

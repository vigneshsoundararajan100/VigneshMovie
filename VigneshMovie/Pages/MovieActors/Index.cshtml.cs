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
    public class IndexModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public IndexModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

        public IList<MovieActor> MovieActor { get;set; }

        public async Task OnGetAsync()
        {
            MovieActor = await _context.MovieActor
                .Include(m => m.Actor)
                .Include(m => m.Movies).ToListAsync();
        }
    }
}

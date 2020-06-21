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
    public class IndexModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public IndexModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

        public IList<Movies> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
  
        }
    }
}

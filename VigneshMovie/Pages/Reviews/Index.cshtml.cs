using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VigneshMovie.Data;
using VigneshMovie.Model;

namespace VigneshMovie.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public IndexModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; }

        public async Task OnGetAsync()
        {
            Review = await _context.Review
                .Include(r => r.Movies)
                .Include(r => r.Person).ToListAsync();
        }
    }
}

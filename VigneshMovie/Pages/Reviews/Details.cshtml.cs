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
    public class DetailsModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public DetailsModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Review
                .Include(r => r.Movies)
                .Include(r => r.Person).FirstOrDefaultAsync(m => m.ReviewId == id);

            if (Review == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

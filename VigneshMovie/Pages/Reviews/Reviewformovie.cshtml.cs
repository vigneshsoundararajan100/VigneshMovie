using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VigneshMovie.Model;
using VigneshMovie.Data;
using Microsoft.EntityFrameworkCore;

namespace VigneshMovie.Pages.Reviews
{
    public class ReviewformovieModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public ReviewformovieModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }
        public IList<Review> Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Review = await _context.Review
                 .Where(s => s.MovieId==id)
                 .Include(r => r.Movies)
                 .Include(r => r.Person).ToListAsync(); 
            
            if (Review == null)
            { 
                return NotFound();
            }
            return Page();
        }




    }
}
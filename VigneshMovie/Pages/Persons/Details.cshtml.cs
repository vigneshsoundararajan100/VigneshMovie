using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VigneshMovie.Data;
using VigneshMovie.Model;

namespace VigneshMovie.Pages.Persons
{
    public class DetailsModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public DetailsModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.PersonId == id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

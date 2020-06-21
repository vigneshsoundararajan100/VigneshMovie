﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VigneshMovie.Data;
using VigneshMovie.Model;

namespace VigneshMovie.Pages.MovieActors
{
    public class CreateModel : PageModel
    {
        private readonly VigneshMovie.Data.VigneshMovieContext _context;

        public CreateModel(VigneshMovie.Data.VigneshMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ActorId"] = new SelectList(_context.Actor, "ActorId", "ActorName");
        ViewData["MovieId"] = new SelectList(_context.Movies, "MovieId", "MovieName");
            return Page();
        }

        [BindProperty]
        public MovieActor MovieActor { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieActor.Add(MovieActor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

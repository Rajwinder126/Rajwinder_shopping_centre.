using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rajwinder_shopping_centre.Data;
using Rajwinder_shopping_centre.Models;

namespace Rajwinder_shopping_centre.Pages.Signups
{
    public class DetailsModel : PageModel
    {
        private readonly Rajwinder_shopping_centre.Data.Rajwinder_shopping_centreDatabase _context;

        public DetailsModel(Rajwinder_shopping_centre.Data.Rajwinder_shopping_centreDatabase context)
        {
            _context = context;
        }

        public Signup Signup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Signup = await _context.Signup.FirstOrDefaultAsync(m => m.Id == id);

            if (Signup == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

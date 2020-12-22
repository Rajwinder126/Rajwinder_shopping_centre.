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
    public class DeleteModel : PageModel
    {
        private readonly Rajwinder_shopping_centre.Data.Rajwinder_shopping_centreDatabase _context;

        public DeleteModel(Rajwinder_shopping_centre.Data.Rajwinder_shopping_centreDatabase context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Signup = await _context.Signup.FindAsync(id);

            if (Signup != null)
            {
                _context.Signup.Remove(Signup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

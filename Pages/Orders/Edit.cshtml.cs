using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rajwinder_shopping_centre.Data;
using Rajwinder_shopping_centre.Models;

namespace Rajwinder_shopping_centre.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly Rajwinder_shopping_centre.Data.Rajwinder_shopping_centreDatabase _context;

        public EditModel(Rajwinder_shopping_centre.Data.Rajwinder_shopping_centreDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.Product)
                .Include(o => o.Signup).FirstOrDefaultAsync(m => m.Id == id);

            if (Order == null)
            {
                return NotFound();
            }
           ViewData["ProductId"] = new SelectList(_context.Set<Product>(), "Id", "Product_Name");
           ViewData["SignupId"] = new SelectList(_context.Set<Signup>(), "Id", "Signup_Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.Id))
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

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }
}

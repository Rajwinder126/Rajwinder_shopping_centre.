using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rajwinder_shopping_centre.Data;
using Rajwinder_shopping_centre.Models;

namespace Rajwinder_shopping_centre.Pages.Brands
{
    public class IndexModel : PageModel
    {
        private readonly Rajwinder_shopping_centre.Data.Rajwinder_shopping_centreDatabase _context;

        public IndexModel(Rajwinder_shopping_centre.Data.Rajwinder_shopping_centreDatabase context)
        {
            _context = context;
        }

        public IList<Brand> Brand { get;set; }

        public async Task OnGetAsync()
        {
            Brand = await _context.Brand.ToListAsync();
        }
    }
}

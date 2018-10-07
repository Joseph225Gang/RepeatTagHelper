using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MVAAspCorePractise2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public IList<Customer> Customers { get; private set; }
        [TempData]
        public string Message { get; set; }

        public async Task OnGet()
        {
            Customers = await _db.Customer.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var cutomer = await _db.Customer.FindAsync(id);

            if(cutomer != null)
            {
                _db.Customer.Remove(cutomer);
                await _db.SaveChangesAsync();
            }
            return RedirectToPage();

        }
    }
}

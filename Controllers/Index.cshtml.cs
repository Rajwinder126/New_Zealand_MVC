using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using New_Zealand_MVC.Data;
using New_Zealand_MVC.Models;

namespace New_Zealand_MVC.Controllers
{
    public class IndexModel : PageModel
    {
        private readonly New_Zealand_MVC.Data.New_Zealand_MVCDatabase _context;

        public IndexModel(New_Zealand_MVC.Data.New_Zealand_MVCDatabase context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}

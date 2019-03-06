using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages.Movies
{
    public class IndexModel : PageModel
    {
        //this is the same
        private readonly WebApplication2.Models.WebApplication2Context _context;

        //as is this
        public IndexModel(WebApplication2.Models.WebApplication2Context context)
        {
            _context = context;
        }

        //and this
        public IList<Movie> Movie { get;set; }

        //this is the same too minus the tracking
        //No SQL strings
        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}

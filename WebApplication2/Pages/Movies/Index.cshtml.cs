using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Pages.Movies {
    public class IndexModel : PageModel {
        //1. this is the same
        private readonly WebApplication2.Models.WebApplication2Context _context;

        //2. as is this
        public IndexModel(WebApplication2.Models.WebApplication2Context context) {
            _context = context; // Why couldn't I have renamed this _db so it stands for database.
        }

        //3. and this
        public IList<Movie> Movie { get; set; }

        //A. Searching via genre or name

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } // this will be a text box in razor

        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }


        public async Task OnGetAsync() {
            // E. Add genre filter here - this is acquiring all current genres and making a validation list
            IQueryable<string> genreQuery = from m in _context.Movie orderby m.Genre select m.Genre;

            //B. Adding the search function
            var movies = from m in _context.Movie select m; //Linq function eh

            if (!string.IsNullOrEmpty(SearchString)) {
                movies = movies.Where(s => s.Title.Contains(SearchString)); // Contains remaps to SQL_LIKE
            }

            // F. Genre stuff
            if (!string.IsNullOrEmpty(MovieGenre)) {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Genres = new SelectList (await genreQuery.Distinct().ToListAsync());

            //4. this is the same too minus the tracking
            //5. No SQL strings, get entire list and is all
            //Movie = await _context.Movie.ToListAsync();
            Movie = await movies.ToListAsync(); // C. The search function omits the _context because it has been filtered beforehand

            // D. search via e.g. https://localhost:44380/Movies?searchString=Ghost
            // It is also possible to search by making https://localhost:5001/Movies/Ghost.cshtml with @Page "{searchString?}". this is called route data
            // Probably would use that for genres only, it isn't a good way to search via url modification
        }
    }
}

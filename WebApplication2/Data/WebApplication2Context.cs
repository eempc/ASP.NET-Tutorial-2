using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models {
    public class WebApplication2Context : DbContext {
        public WebApplication2Context(DbContextOptions<WebApplication2Context> options)
            : base(options) {
        }

        // ef migrations add InitialCreate. coordinates the CRUD
        public DbSet<WebApplication2.Models.Movie> Movie { get; set; }
    }
}

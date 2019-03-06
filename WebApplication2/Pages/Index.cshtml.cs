using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Dynamic web page. But why use this over JS?

namespace WebApplication2.Pages {
    public class IndexModel : PageModel {
        //public string message { get; private set; } = "Something ";
        public string message { get; set; }
        public string message2 { get; set; }
        public void OnGet() {
            message += $"Date: { DateTime.Now }";
            message2 = squared(3.5).ToString();
        }

        public double squared (double x) {
            return Math.Pow(x, 2);
        }
    }
}

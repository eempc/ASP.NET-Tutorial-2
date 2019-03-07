using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Make class then CRUD scaffold it

namespace WebApplication2.Models {
    public class Movie {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3), Required] // One line for both
        public string Title { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } // Is date picker

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")] // Alphanumeric constraint with capital first
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } // Late field addition. Then build solution. Then add field markup to index, delete, edit, details cshtml files, then add the db column (multiple ways, tutorial says to use Code First Migrations). Update SeedData. Then use PMC to do the terminal commands again (Add Migration rating) and update database
    }
}

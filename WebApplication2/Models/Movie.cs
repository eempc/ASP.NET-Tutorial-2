﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

// Make class then CRUD scaffold it

namespace WebApplication2.Models {
    public class Movie {
        public int ID { get; set; }
        public string Title { get; set; }
        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } // Is date picker
        public string Genre { get; set; }

        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }
    }
}
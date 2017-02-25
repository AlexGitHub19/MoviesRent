using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace MoviesRent.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }
}
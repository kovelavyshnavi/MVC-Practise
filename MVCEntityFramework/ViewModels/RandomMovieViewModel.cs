using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCEntityFramework.Models;

namespace MVCEntityFramework.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movies> Movie { get; set; }
        public List<Customers> Customers { get; set; }
    }
}
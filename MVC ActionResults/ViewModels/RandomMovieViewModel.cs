using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_ActionResults.Models;

namespace MVC_ActionResults.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movies> Movie { get; set; }
        public List<Customers> Customers { get; set; }
    }
}
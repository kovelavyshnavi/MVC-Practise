using MVC_ActionResults.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_ActionResults.ViewModels
{
    public class MovieViewModel
    {
        public Movies Movies { get; set; }
        public IEnumerable<Genres> Genres { get; set; }


        public string Title
        {
            get
            {
                if (Movies != null && Movies.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}
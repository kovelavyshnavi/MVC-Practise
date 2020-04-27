﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEntityFramework.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Customers Customers { get; set; }
        [Required]
        public Movies Movies { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}
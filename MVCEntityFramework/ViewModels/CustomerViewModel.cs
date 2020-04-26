using MVCEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEntityFramework.ViewModels
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }

        public Customers Customers { get; set; }

        public string Title
        {
            get
            {
                if (Customers != null && Customers.Id != 0)
                    return "Edit Customer";

                return "New Customer";
            }
        }
    }
}
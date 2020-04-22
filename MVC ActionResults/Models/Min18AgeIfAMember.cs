using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ActionResults.Models
{
    public class Min18AgeIfAMember
    {
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public sealed class ValidBirthDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var customer = (Customers)validationContext.ObjectInstance;

                if (customer.MembershipTypeId == 1)
                    return ValidationResult.Success;

                if (customer.Birthdate == null)
                    return new ValidationResult("BirthDate is required.");

                var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
                return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18 years old to go on a Membership.");

            }
        }
    }
}
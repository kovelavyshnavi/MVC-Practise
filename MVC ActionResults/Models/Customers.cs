using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_ActionResults.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsLetter { get; set; }
   
        public MembershipTypes MembershipType { get; set; }

        [Display(Name="MemberShipType")]
        public byte MembershipTypeId { get; set; }

        [Display(Name="Date Of Birth")]
        [Min18AgeIfAMember.ValidBirthDate]
        public DateTime? Birthdate { get; set; }
    }
}
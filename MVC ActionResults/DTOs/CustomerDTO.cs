using MVC_ActionResults.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ActionResults.DTOs
{
    public class CustomerDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }
        [Display(Name = "MemberShipType")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        //[Min18AgeIfAMember.ValidBirthDate]
        public DateTime? Birthdate { get; set; }
    }
}
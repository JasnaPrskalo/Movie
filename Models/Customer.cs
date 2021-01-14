using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSbscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        //foreign key
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}

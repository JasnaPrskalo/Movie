using MovieShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieShop.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

      //  [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSbscribedToNewsletter { get; set; }

        //this property is creatin dependency from our DTO to the domain model
        //public MembershipType MembershipType { get; set; }

        //foreign key
        public byte MembershipTypeId { get; set; }
    }
}
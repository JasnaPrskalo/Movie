using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.Models
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //check the selected membershiptype 
            var customer = (Customer)validationContext.ObjectInstance;

               //If user does not select MembershipType OR user select payAsYouGo
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAdYouGo) //If customer choose PayAsYouGo(Id=1) 
                return ValidationResult.Success; //Success is static field on the ValidationResult class

            if (customer.Birthdate == null)//If customer choose any other MembershipType, maust have 18years
                return new ValidationResult("Birthdate is required");

            //Calculate the year
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
                //after checking the birth year the result is Success or error message
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}
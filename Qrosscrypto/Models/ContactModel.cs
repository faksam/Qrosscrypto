using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Qrosscrypto.Models
{
    public class ContactModel
    {
        [Required]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "E-mail Address: ")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone No: ")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Message: ")]
        [StringLength(500, ErrorMessage = "Field cannot be longer than 500 characters.")]
        public string Message { get; set; }
    }
}
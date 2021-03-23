using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.Models
{
    public class AdminClass
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter First name")]
        [DisplayName("First Name")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Length should be atleast 3")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Enter Last name")]
        [DisplayName("Last Name")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Length should be atleast 3")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Enter the age")]
        [DisplayName("Age")]
        public long Age { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Contact number")]
        [DisplayName("Contact Number")]
        public long Contact { get; set; }

        [Required(ErrorMessage = "Enter User name")]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
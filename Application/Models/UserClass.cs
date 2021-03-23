using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TeacherStudentConnect.Models
{
    public class UserClass
    {
        [Required(ErrorMessage = "Enter First name")]
        [DisplayName("First Name")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Enter Last name")]
        [DisplayName("Last Name")]
        public string Lname { get; set; }

        [Required(ErrorMessage = "Enter the age")]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Contact number")]
        [DisplayName("Contact Number")]
        public long Contact { get; set; }

        [Required(ErrorMessage = "Enter Category")]
        [DisplayName("Enter category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Enter User name")]
        [DisplayName("User Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Upload profile image")]
        [DisplayName("Profile image")]
        public string Picture { get; set; }
    }
}